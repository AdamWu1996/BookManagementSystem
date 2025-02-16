# 書本管理系統 (Book Management System)

此專案是回答面試題目所實作的簡易書本管理系統，使用 C# 與 MySQL。專案架構採用 **MVC 架構** 以提高維護性。

## 題目說明

請使用 C# 與 MySQL 開發一個簡單的 書本管理系統，包含 書籍管理、借閱管理 及 使用者管理。

### 功能需求

#### 書籍管理
* 新增、編輯、刪除、查詢書籍
* 書籍欄位：書名、作者、出版社、分類、數量

#### 借閱管理
* 記錄書籍借出與歸還時間
* 當書籍數量為 0 時，無法借閱

#### 使用者管理
* 註冊、登入（帳號密碼驗證）
* 權限管理（管理員(新增、編輯、刪除) / 一般使用者(僅能查詢/借出)）
  
#### 技術要求
* 開發語言：C#
* 資料庫：MSSQL
* 錯誤處理：需有基本的錯誤處理機制(e.g. try catch)

## 功能介紹

### 書籍管理

- 新增書籍
- 編輯書籍
- 刪除書籍
- 查詢書籍

### 借閱管理

- 記錄書籍借出與歸還時間
- 當書籍數量為 0 時，無法借閱

### 用戶管理

- 用戶註冊
- 用戶登入 ( 帳號/密碼驗證 )
- 權限管理：
  - 管理員（新增、編輯、刪除、查詢、借出書籍）
  - 一般用戶（查詢、借出書籍）

## 技術棧

- 開發語言：C# (.NET 9.0)
- 資料庫：MySQL
- 專案套件：MySql.Data (9.2.0)
- 模式：MVC 架構 + Repository 模式

## 安裝與使用

### 環境需求

- .NET SDK 9.0+
- MySQL 8.4+

### 部署步驟

1. 先確保您已安裝 .NET 9.0 及 MySQL
2. 先將資料庫組態建立（檔案在 `scripts/db_setup.sql`）
3. 在 MySQL 中執行檔案內容
4. 在根目錄執行以下指令啟動應用

```sh
cd BookManagementSystem
dotnet run
```

## 檔案架構 (MVC 架構)

```
.
├── Controllers        // MVC - 控制器 (Controller)
│   ├── BookController.cs   // 書本管理
│   ├── BorrowController.cs // 借閱管理
│   └── UserController.cs   // 使用者管理
├── DataAccess              // 資料庫管理
│   └── DBHelper.cs
├── Models           // MVC - 模型 (Model)
│   ├── Book.cs
│   ├── BorrowRecord.cs
│   └── User.cs
├── Repository       // 資料庫對接層
│   ├── BookRepository.cs
│   ├── BorrowRepository.cs
│   └── UserRepository.cs
├── Program.cs       // 入口點
└── BookManagementSystem.csproj  // 專案配置
```


