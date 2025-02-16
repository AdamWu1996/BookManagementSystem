CREATE DATABASE library;
USE library;

-- 書籍表格
CREATE TABLE books (
    title VARCHAR(255) NOT NULL,
    author VARCHAR(255) NOT NULL,
    publisher VARCHAR(255) NOT NULL,
    category VARCHAR(255),
    quantity INT NOT NULL DEFAULT 0,
    PRIMARY KEY (title, author, publisher) -- 複合主鍵
);

-- 使用者表格
CREATE TABLE users (
    account VARCHAR(50) ,
    password VARCHAR(255) NOT NULL,
    role BOOLEAN NOT NULL DEFAULT FALSE -- 角色：TRUE 為管理員，FALSE 為一般使用者
);

-- 借閱記錄表格
CREATE TABLE borrow_records (
    book_title VARCHAR(255) NOT NULL,
    book_author VARCHAR(255) NOT NULL,
    book_publisher VARCHAR(255) NOT NULL,
    account VARCHAR(50) NOT NULL,
    borrow_date DATETIME NOT NULL,
    return_date DATETIME
);

-- 插入書籍資料 (考慮 title, author, publisher 三個主鍵)
INSERT INTO books (title, author, publisher, category, quantity) VALUES
('C# 程式設計', '張三', '清華出版社', '程式設計', 5),
('C# 程式設計', '張三', '高立出版社', '程式設計', 3), -- 相同 title 但不同出版社
('Python 入門', '李四', '電子工業出版社', '人工智慧', 8),
('Python 入門', '王五', '電子工業出版社', '人工智慧', 2), -- 相同 title 但不同 author
('深入淺出 Java', 'Tom Brown', 'O''Reilly', '程式設計', 6),
('深入淺出 Java', 'Tom Brown', '清華出版社', '程式設計', 4), -- 相同 title 但不同出版社
('資料庫設計與應用', 'Alice Chen', '高立出版社', '資料庫', 10),
('資料庫設計與應用', 'Alice Chen', '電子工業出版社', '資料庫', 7), -- 相同 title 但不同出版社
('機器學習基礎', '王五', '電子工業出版社', '人工智慧', 9),
('演算法分析', 'David Johnson', 'MIT Press', '演算法', 5);

-- 插入使用者資料 (包含管理員與一般使用者)
INSERT INTO users (account, password, role) VALUES
('user1', 'password123', FALSE),
('user2', 'password456', FALSE),
('admin1', 'adminpass', TRUE),
('user3', 'securepass', FALSE),
('admin2', 'strongadmin', TRUE);

-- 插入借閱記錄 (考慮三個外鍵 book_title, book_author, book_publisher)
INSERT INTO borrow_records (book_title, book_author, book_publisher, account, borrow_date, return_date) VALUES
('C# 程式設計', '張三', '清華出版社', 'user1', '2024-02-01 10:00:00', NULL), -- 借閱未歸還
('Python 入門', '李四', '電子工業出版社', 'user2', '2024-02-05 15:30:00', '2024-02-10 12:00:00'), -- 已歸還
('深入淺出 Java', 'Tom Brown', 'O''Reilly', 'user1', '2024-02-07 09:45:00', NULL), -- 借閱未歸還
('資料庫設計與應用', 'Alice Chen', '高立出版社', 'user3', '2024-02-08 14:20:00', NULL), -- 借閱未歸還
('機器學習基礎', '王五', '電子工業出版社', 'user2', '2024-02-09 11:00:00', '2024-02-13 16:00:00'), -- 已歸還
('演算法分析', 'David Johnson', 'MIT Press', 'user3', '2024-02-10 17:30:00', NULL), -- 借閱未歸還
('C# 程式設計', '張三', '高立出版社', 'user1', '2024-02-11 09:00:00', NULL), -- 借閱未歸還
('Python 入門', '王五', '電子工業出版社', 'user2', '2024-02-12 13:45:00', NULL), -- 借閱未歸還
('深入淺出 Java', 'Tom Brown', '清華出版社', 'admin1', '2024-02-13 10:10:00', NULL), -- 借閱未歸還
('資料庫設計與應用', 'Alice Chen', '電子工業出版社', 'admin2', '2024-02-14 16:25:00', NULL); -- 借閱未歸還

