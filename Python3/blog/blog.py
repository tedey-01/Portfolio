import pyodbc
import random
from random import choice
from string import ascii_letters


class BackEnd:
    def __init__ (self, server_name='DESKTOP-7ASGC0A', db_name='Python_blog', login='sa' , password='Dawidastme01'):
        self.connection=pyodbc.connect('DRIVER={SQL Server};SERVER='+server_name+';DATABASE='+db_name+'; UID='+login+'; PWD='+password)
        self.cursor=self.connection.cursor()


    def add_user(self, nick_name, login, password, activity=0):
        self.cursor.execute(
                "INSERT INTO [User] (nickName, activity, [login], [password]) \
                VALUES ('"+nick_name+"',"+str(activity)+", '"+login+"','"+password+"')")
        self.connection.commit()


    def authorize(self, login, password):
        self.cursor.execute("SELECT [user_id] FROM [USER] WHERE login='"+login+"' AND password='"+password+"'")
        ans=self.cursor.fetchall()
        if ans:
            self.cursor.execute("UPDATE [User] SET activity=1 WHERE login='"+login+"' AND password='"+password+"'")
            self.connection.commit()
        else :
            print("This account is already authoried")

            
    def users_list(self):
        self.cursor.execute("SELECT nickName, activity FROM [User]")
        result=self.cursor.fetchall()
        print ("------------------users------------------")
        for x in result:
            print (x[0].rstrip(), '\t', x[1])


    def create_blog (self,creater_id, blog_name, existence=1):
        self.cursor.execute("INSERT INTO Blogs (creater_id, [name], existence) VALUES ("+str(creater_id)+", '"+blog_name+"', "+str(existence)+")")
        self.connection.commit()

        
    def delete_blog (self, blog_id):
        self.cursor.execute("UPDATE Blogs SET existence=0  WHERE blog_id="+str(blog_id))
        self.connection.commit() 


    def show_blogs(self):
        self.cursor.execute("SELECT Blogs.name, nickName FROM Blogs LEFT JOIN [User] ON creater_id= [user_id] WHERE existence=1" )
        result=self.cursor.fetchall()
        print ("----------------active blogs----------------")
        for el in result:
            print (el[0].rstrip(), "\t", el[1].rstrip())


    def active_hosts_blogs(self):
        self.cursor.execute("SELECT Blogs.name, nickName FROM Blogs LEFT JOIN [User] ON creater_id=[user_id] WHERE activity=1 AND existence =1")
        result=self.cursor.fetchall()
        print("----------------active hosts blogs----------")
        for el in result:
            print (el[0].rstrip(),"\t", el[1].rstrip())

    def create_post (self, creater_id, header, content, blog_id):
        self.cursor.execute(
                "INSERT INTO Post (creater_id, header, content, existence) \
                VALUES ("+str(creater_id)+", '"+header+"', '"+content+"', 1) \
                \
                INSERT INTO Blog_content (blog_id, post_id) \
                VALUES ("+str(blog_id)+", (SELECT SCOPE_IDENTITY()))")
        self.connection.commit()
        

    def change_post_header(self, post_id, new_header):
        self.cursor.execute("UPDATE Post SET header='"+new_header+"' WHERE post_id="+str(post_id))
        self.connection.commit()


    def chnge_post_content(self, post_id, new_content):
        self.cursor.execute("UPDATE Post SET content='"+new_content+"' WHERE post_id="+str(post_id))
        self.connection.commit()


    def change_post_place(self, post_id, variable_blogs, wishful_blogs):
        request_string="DELETE FROM Blog_content WHERE post_id IN "+str(tuple(variable_blogs))
        for x in wishful_blogs:
            request_string+="\nINSERT INTO Blog_content (blog_id, post_id)  VALUES ("+str(x)+", "+str(post_id)+")"
        self.cursor.execute(request_string)
        self.connection.commit()


    def delete_post(self, post_id):
        self.cursor.execute("DELETE FROM Post WHERE post_id="+str(post_id))
        self.connection.commit()


    def add_comment(self, user_id, post_id, comment):
        self.cursor.execute("SELECT activity FROM [User] WHERE [user_id]="+str(user_id))
        ans=self.cursor.fetchall()
        if ans[0][0]:
            self.cursor.execute("INSERT INTO Comments (creater_id, post_id, content) VALUES ("+str(user_id)+","+str(post_id)+",'"+comment+"')")
            self.connection.commit()


    def post_comments(self, post_id):
        self.cursor.execute("SELECT nickName, content FROM Comments LEFT JOIN [User] ON creater_id =[user_id] WHERE post_id="+str(post_id))
        result=self.cursor.fetchall()
        print("----------post comments-------------")
        for x in result:
            print (x[0].rstrip(),"\t", x[1].rstrip())

    def attached_to_blog(self,blog_id, user_id):
        self.cursor.execute("INSERT INTO Blog_users (blog_id, [user_id]) VALUES ("+str(blog_id)+", "+str(user_id)+")")
        self.connection.commit()

#-----------------------------------------------------------------------------------------
#генерирует случайтые данные для 1 пользователя
def user_generator():
    name=(''.join(choice(ascii_letters) for i in range(9)))
    activity = random.getrandbits(1)
    login = (''.join(choice(ascii_letters) for i in range(12)))
    password=str(random.randrange(1_000_000, 10_000_000))
    return [name, login, password, activity]

#генерирует случайтые данные для 1 блога
def blog_generator():
    blog_name=(''.join(choice(ascii_letters) for i in range (random.randint(10, 35))))
    existence=random.getrandbits(1)
    return [blog_name, existence]

#генерирует случайнеу заголовки и тексты к постам
def post_generator():
    header=(''.join(choice(ascii_letters) for i in range (random.randint(10, 35))))
    content=''.join(choice(ascii_letters) for i in range (random.randint(20, 100)))
    existence=random.getrandbits(1)
    return [header, content, existence]

#------------------------------------------------------------------------------------------

#заполняет таблицу User случайными данными
def fill_users(obj):
    for i in range(100):
        params=user_generator()
        obj.add_user(params[0], params[1], params[2], params[3])
        

#заполняет таблибу Blogs случайными данными 
def fill_blogs(obj):
    obj.cursor.execute("SELECT TOP 10 [user_id]  FROM [User] ORDER BY NEWID()")
    creaters=obj.cursor.fetchall()
    for k in range(10):
        params=blog_generator()
        obj.create_blog(creaters[k][0],params[0], params[1])


#заполняет таблицы Post и Blog_content случайными данными
def fill_posts(obj):
    obj.cursor.execute("SELECT TOP 50 [user_id]  FROM [User] ORDER BY NEWID()")
    creaters=obj.cursor.fetchall()
    obj.cursor.execute("SELECT TOP 10 blog_id FROM Blogs ORDER BY NEWID()")
    blog_ids=obj.cursor.fetchall()
    for k in range(200):
        params=post_generator()
        obj.create_post(creaters[k%50][0],params[0], params[1], blog_ids[k%10][0])

        
#заполняет таблицу Comments случайными данными 
def fill_comments(obj):
    obj.cursor.execute("SELECT post_id FROM Post ORDER BY NEWID()")
    post_ids=obj.cursor.fetchall()
    obj.cursor.execute("SELECT TOP 100 [user_id] FROM [User] ORDER BY NEWID()")
    creaters=obj.cursor.fetchall()
    for x in range(500):
        content=''.join(choice(ascii_letters) for i in range(random.randint(10, 40)))
        obj.add_comment(creaters[random.randint(1, 99)][0], post_ids[random.randint(1,200)][0], content )

def fill_blog_users(obj):
    obj.cursor.execute("SELECT [user_id] FROM [User] ORDER BY NEWID()")
    users=obj.cursor.fetchall()
    obj.cursor.execute("SELECT blog_id FROM Blogs")
    blogs=obj.cursor.fetchall()
    for x in range(len(users)):
        for i in range(random.randint(1,3)):
            obj.attached_to_blog(blogs[random.randint(1,len(blogs)-1)][0], users[x][0])
        

def main():
    website=BackEnd()

    
if __name__=='__main__':
    main()
