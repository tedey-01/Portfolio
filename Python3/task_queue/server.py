import argparse
import socket
import threading
import os
import pickle
import time


# нода
class node:

    def __init__(self, id_num, text):
        self._id = id_num
        self._flag = 0
        self._text = text
        self._addr = 0


    def set_flag(self, i):
        self._flag = i


    def set_addr(self, addr):
        self._addr = addr


class myqueue:
    def __init__(self, name):
        self.name = name
        self.queue = []

    # добавидли узел (задание)
    def add(self, id_num, context):
        temp = node(id_num, context)
        self.queue.append(temp)

    # удаляем узел(задание)
    def remove(self, id_num):
        i = -1
        for el in self.queue:
            i += 1
            if el._id == id_num:
                break
        self.queue.pop(i)

    # выдаём задание и блокируем его
    def get(self, addr):
        for i in range( 0, len(self.queue), 1):
            if not self.queue[i]._flag:
                self.queue[i].set_addr(addr)
                self.queue[i].set_flag(1)
                return self.queue[i]
        return 'None'

    # проверка на наличие такого задания вне зависимости выполняется ли оно
    def check(self, id_num):
        for el in self.queue:
            if el._id == id_num:
                return 'YES'
        return "NO"

    # подтверждение выполнения задания (проверяем исполнителя)
    def ack(self, id_num, addr):
        for i in range(len(self.queue)):
            if self.queue[i]._addr[0] == addr[0] and self.queue[i]._id == id_num:
                self.remove(id_num)
                return 'YES'
        return 'NO'


class TaskQueueServer:

    def __init__(self, ip, port, path, timeout ):
        self.ip = ip
        self.port = port
        self.path = path
        self.timeout = timeout
        self.sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        self.sock.bind(('0.0.0.0', 5555))
        self.sock.listen(10)
        self.queues = []
        self.id_num = '0'


    def ADD(self, task_name, description):
        self.id_num = str(int(self.id_num) + 1)
        fl = 0
        for i in range(len(self.queues)):
            if self.queues[i].name == task_name:
                self.queues[i].add(self.id_num, description)
                fl = 1
                break
        if fl == 0:
            temp = myqueue(task_name)
            self.queues.append(temp)
            self.queues[-1].add(self.id_num, description)
        return self.id_num


    def GET(self, task_name, addr):
        for i in range(len(self.queues)):
            if self.queues[i].name == task_name:
                temp = self.queues[i].get(addr)
                if temp == 'None':
                    return temp
                else:
                    cort = (temp._id, len(temp._text), temp._text)
                    return cort
            else:
                return 'None'


    def ACK(self, task_name, id_num, addr):
        for i in range(len(self.queues)):
            if self.queues[i].name == task_name:
                return self.queues[i].ack(id_num, addr)
        return "NO"


    def CHECK(self, task_name, id_num):
        for i in range(len(self.queues)):
            if self.queues[i].name == task_name:
                t = self.queues[i].check(id_num)
                return t
        return "NOT"


    def run(self):
        while True:
            conn, addr = self.sock.accept()
            data = conn.recv(20)
            conn_list = (data.decode()).split(" ")
            if conn_list[0] == 'ADD':
                if conn_list[3]:
                    conn_list[3] = conn_list[3] + (conn.recv(int(conn_list[2])-len(conn_list[3]))).decode()
                else:
                    conn_list.append(conn.recv(int(conn_list[2])))
                qw = self.ADD(conn_list[1], conn_list[3])
                conn.send(qw.encode())
            elif conn_list[0] == "GET":
                qw = self.GET(conn_list[1], addr)
                if qw == 'None':
                    conn.send(qw.encode())
                else:
                    conn.send((str(qw[0]) + " "+str(qw[1]) + " "+str(qw[2])).encode())
            elif conn_list[0] == "ACK":
                qw = self.ACK(conn_list[1], conn_list[2], addr)
                conn.send(qw.encode())
            elif conn_list[0] == "IN":
                qw = self.CHECK(conn_list[1], conn_list[2])
                conn.send(qw.encode())
            elif conn_list[0]=="SAVE":
                with open("save_queues.pickle", "wb") as f:
                    pickle.dump(self.queues, f)
                flag=os.stat("save_queues.pickle").st_size!=0
                if flag:
                    flag = "Success"
                else:
                    flag = "fail"
                conn.send(flag.encode())
            else:
                conn.send(b'ERROR')
            conn.shutdown(1)
            conn.close()

def parse_args():
    parser = argparse.ArgumentParser(description='This is a simple task queue server with custom protocol')
    parser.add_argument(
        '-p',
        action="store",
        dest="port",
        type=int,
        default=5555,
        help='Server port')
    parser.add_argument(
        '-i',
        action="store",
        dest="ip",
        type=str,
        default='0.0.0.0',
        help='Server ip adress')
    parser.add_argument(
        '-c',
        action="store",
        dest="path",
        type=str,
        default='./',
        help='Server checkpoints dir')
    parser.add_argument(
        '-t',
        action="store",
        dest="timeout",
        type=int,
        default=300,
        help='Task maximum GET timeout in seconds')
    return parser.parse_args()


if __name__ == '__main__':
    args = parse_args()
    server = TaskQueueServer(args.ip, args.port, args.path, args.timeout)
    server.run()
