using Core.Helpers;
using System;
using System.Linq;

namespace Core.Data
{
    public class AppData
    {
        public static void Seed(AppDbContext context)
        {
            if (context.BlogPosts.Any())
                return;

            context.Authors.Add(new Author
            {
                AppUserName = "admin",
                Email = "admin@wzu.edu.cn",
                DisplayName = "Administrator",
                Avatar = "data/admin/avatar.png",
                Bio = "",
                IsAdmin = true,
                Created = DateTime.Now.AddDays(-120)
            });

            context.Authors.Add(new Author
            {
                AppUserName = "demo",
                Email = "demo@wzu.edu.cn",
                DisplayName = "Demo user",
                Bio = "",
                Created = DateTime.Now.AddDays(-110)
            });

            context.SaveChanges();

            var adminId = context.Authors.Single(a => a.AppUserName == "admin").Id;
            var demoId = context.Authors.Single(a => a.AppUserName == "demo").Id;

            context.BlogPosts.Add(new BlogPost
            {
                Title = "欢迎来到我的博客",
                Slug = "welcome-to-myblog!",
                Description = "管理员文章",
                Content = "管理员文章",
                Categories = "welcome,blog",
                AuthorId = adminId,
                Cover = "data/admin/cover-blog.png",
                PostViews = 5,
                Rating = 4.5,
                IsFeatured = true,
                Published = DateTime.Now.AddDays(-100)
            });

            context.BlogPosts.Add(new BlogPost
            {
                Title = "用户测试",
                Slug = "demo-post",
                Description = "测试文章",
                Content = "测试文章",
                AuthorId = demoId,
                Cover = "data/demo/demo-cover.jpg",
                PostViews = 25,
                Rating = 3.5,
                Published = DateTime.UtcNow.AddDays(-10)
            });

            context.Notifications.Add(new Notification
            {
                Notifier = "welcome to my blog ! ",
                AlertType = AlertType.Primary,
                AuthorId = 0,
                Content = "Welcome to my blog ! ",
                Active = true,
                DateNotified = SystemClock.Now()
            });

            context.SaveChanges();
        }
    }

    public class SeedData
    {
        public static readonly string FeaturedDesc = @"Blogifier is simple, beautiful, light-weight open source blog written in .NET Core. This cross-platform, highly extendable and customizable web application brings all the best blogging features in small, portable package.

#### To login:
* User: demo
* Pswd: demo";

        public static readonly string PostWhatIs = @"## What is Blogifier

Blogifier is simple, beautiful, light-weight open source blog written in .NET Core. This cross-platform, highly extendable and customizable web application brings all the best blogging features in small, portable package.

## System Requirements

* Windows, Mac or Linux
* ASP.NET Core 2.1
* Visual Studio 2017, VS Code or other code editor (Atom, Sublime etc)
* SQLite by default, MS SQL Server tested, EF compatible databases should work

## Getting Started

1. Clone or download source code
2. Run application in Visual Studio or using your code editor
3. Use admin/admin to log in as admininstrator
4. Use demo/demo to log in as user

## Demo site

The [demo site](http://blogifier.azurewebsites.net) is a playground to check out Blogifier features. You can write and publish posts, upload files and test application before install. And no worries, it is just a sandbox and will clean itself.

![Demo-1.png](/data/admin/admin-editor.png)";

        public static readonly string PostFeatures = @"### User Management
Blogifier is multi-user application with simple admin/user roles, allowing every user write and publish posts and administrator create new users.

### Content Management
Built-in file manager allows upload images and files and use them as links in the post editor.

![file-mgr.png](/data/admin/admin-files.png)

### Plugin System
Blogifier built as highly extendable application allowing themes, widgets and modules to be side-loaded and added to blog at runtime.

### Markdown Editor
The post editor uses markdown syntax, which many writers prefer over HTML for its simplicity.

### Simple Search
There is simple but quick and functional search in the post lists, as well as search in the image/file list in the file manager.

### Features in the work
* Plugin management";

        public static readonly string PostDemo = @"This demo site is a sandbox to test Blogifier features. It runs in-memory and does not save any data, so you can try everything without making any mess. Have fun!

#### To login:
* User: demo
* Pswd: demo";

    }
}
