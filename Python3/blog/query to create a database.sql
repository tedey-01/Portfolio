CREATE DATABASE Python_Blog
USE Python_Blog

--������� ������������ 

CREATE TABLE [User]
( 
[user_id] int NOT NULL IDENTITY, 
nickName char(50) NOT NULL,
activity bit NULL,
[login] char (50) NOT NULL,
[password] char (50) NOT NULL,
PRIMARY KEY ([user_id])
)

--������� ������
CREATE TABLE Post
(
post_id int NOT NULL IDENTITY,
creater_id int NOT NULL,
header char(255),
content text NULL,
existence bit NOT NULL DEFAULT 1, 
PRIMARY KEY(post_id)
)

--������� �����������
CREATE TABLE Comments
(
comment_id int NOT NULL IDENTITY, 
[creater_id] int NOT NULL,
post_id  int NOT NULL,
content text NULL,
PRIMARY KEY (comment_id)
)

--������� ������
CREATE TABLE Blogs
(
blog_id int NOT NULL IDENTITY,
creater_id int NOT NULL,
[name] char(50) NOT NULL,
existence bit NOT NULL DEFAULT 1,
PRIMARY KEY(blog_id)
)

--������� ����������� ����� � �������������� 
CREATE TABLE Blog_users
(
id int NOT NULL IDENTITY,
blog_id int  NULL,
[user_id] int  NULL,
PRIMARY KEY(id)
)

--������� ����������� ����� � ����� 
CREATE TABLE Blog_content
(
id int NOT NULL IDENTITY,
blog_id int NOT NULL,
post_id int NOT NULL,
PRIMARY KEY (id)
)


--����������  


-- ������� Blog_user � User
ALTER TABLE Blog_users
ADD FOREIGN KEY (blog_id) REFERENCES Blogs (blog_id)
ON UPDATE CASCADE
ON DELETE CASCADE

-- ������� Blog_user � Blogs
ALTER TABLE Blog_users
ADD FOREIGN KEY ([user_id]) REFERENCES [User] ([user_id]) 
ON UPDATE CASCADE
ON DELETE CASCADE


-- ������� Blog_content � Blogs
ALTER TABLE Blog_content
ADD FOREIGN KEY (blog_id) REFERENCES Blogs (blog_id)
ON UPDATE CASCADE
ON DELETE CASCADE 

-- ������� Blog_content � Post
ALTER TABLE Blog_content
ADD FOREIGN KEY (post_id) REFERENCES Post(post_id)
ON UPDATE CASCADE
ON DELETE CASCADE


-- ������� Post � User
ALTER TABLE Post
ADD FOREIGN KEY (creater_id) REFERENCES [User] ([user_id])
ON UPDATE CASCADE
ON DELETE CASCADE

-- ������� Coments � User
ALTER TABLE Comments
ADD FOREIGN KEY(creater_id) REFERENCES [User] ([user_id])
ON UPDATE CASCADE
ON DELETE CASCADE


-- ������� Comments � Post
ALTER TABLE Comments
ADD FOREIGN KEY (post_id) REFERENCES Post (post_id)
ON UPDATE NO ACTION
ON DELETE NO ACTION

ALTER TABLE Blogs 
ADD FOREIGN KEY (creater_id) REFERENCES [User] ([user_id])
ON UPDATE NO ACTION
