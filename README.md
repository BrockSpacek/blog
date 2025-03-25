### Blog API

### Overview
We are building a simple Blog using .Net and EFCore, as well as JWT Token for Authentication

## Features

** User Creation and Authentication (Login) ** using JWT Tokens
**Create, Update, Publish, and Unpublish our Blogs**
**Soft Delete Blogs** (This will keep them hidden but still in our system just in case the FBI needs :3)
**Search Blogs** (By Different Categories)

## Endpoints 
# User

- `Post /User/CreateUser`
- `Post /User/Login`
- `Get /User/GetUserInfo`

# Blog
- `Post /Blog/AddBlog
- `Get /Blog/GetAllBlogs`
- `Put /Blog/EditBlog`
- `Get /Blog/GetBlogByUserId/{userId}`
- `Delete /Blog/DeleteBlog`
- `Get /Blog/GetBlogByCategory/{category}

## Async Methods in C#

Async Methods in C# are used when queries databases without blocking our main thread

This leads to better performances *Allows us to handle more than one request*

