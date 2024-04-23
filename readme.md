#bootstrap-table.mvc.core (C# / ASP.NET Core MVC) [![nuget package](https://img.shields.io/nuget/v/bootstrap-table.mvc.core.png?style=flat-square)](https://www.nuget.org/profiles/techartdev)

A ASP.NET Core fluent Html helper for the popular [bootstrap-table](https://github.com/wenzhixin/bootstrap-table) plug-in.

Port of the original [bootstrap-table.mvc](https://github.com/simonray/bootstrap-table.mvc) to .NET Core.

To install, run the following command in the Package Manager Console.


```csharp
Install-Package bootstrap-table.mvc.core
```

## Configuration
Add the following css to your project

```css
<link href="bootstrap-table.min.css" rel="stylesheet" />
```

Add the following js to your project
```css
<script src="bootstrap-table.min.js"></script>
```
>

## Usage
You're now ready to start using bootstrap-table.

```csharp
@(Html.BootstrapTable<Person>(Url.Action("GetPeoplePaged"), TablePaginationOption.server)
    .Apply(TableOption.striped)
    .Apply(m => m.Id, ColumnOption.align_center))
```

## Change Log

#### 2.0.0 (23/04/24)
* Upgrade to latest [bootstrap-table](https://github.com/wenzhixin/bootstrap-table)
* Ported to .NET Core
* Fixed TagBuilder and HtmlHelper
* Updated build targets to .NET Standard 2.1, .NET 6 and .NET 8
* Recreated sample web application in .NET 8

#### 1.1.1 (22-02-15)
* Set column title as split camel-case.
* Support for ordered model properties [Display(Order=#)].

#### 1.1.0 (19-02-15)
* Simplify interface and options.
* Removed PagingUrl -> constructor (TablePaginationOption.###).
* Upgrade to latest [bootstrap-table](https://github.com/wenzhixin/bootstrap-table).

#### 1.0.1 (22-01-15)
* Upgrade to latest [bootstrap-table](https://github.com/wenzhixin/bootstrap-table).

#### 1.0.0 (16-01-15)
* Initial Release.

## Acknowledgements

* [bootstrap-table](https://github.com/wenzhixin/bootstrap-table) / [documentation](http://bootstrap-table.wenzhixin.net.cn/)
* [startbootstrap.com](http://startbootstrap.com)

# Support
If you find this project helpful and would like to support the development of more tools and projects, consider buying me a coffee. Your support is greatly appreciated!

[![Buy Me A Coffee](https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png)](https://www.buymeacoffee.com/techartdev)

Thank you for your support!
