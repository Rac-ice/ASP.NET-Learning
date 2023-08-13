## MVC 模式简介

- MVC 模式两种理解：一种是表现模式，另外一种是架构模式
它将应用程序分成三个主要组件即：试图（View）控制器（Controller）模型（Model）
- Mode 主要是存储或者是处理数据的组件
Model其实是实现业务逻辑层对实体类相应数据库操作，如：CRUD；它包括数据、验证规则、数据访问和业务逻辑等应用程序信息
ViewModel：视图模型
- View 是用户接口层组件
主要是将Model中的数据展示给用户，ASPX和ASCS文件被用来处理试图的职责
- Controller 处理用户交互，从Model中获取数据并将数据传给指定的View

![image](https://github.com/Rac-ice/ASP.NET-Learning/assets/56425821/072e9ede-8e78-4eea-a263-944491c6470f)


## MVC架构模式

![image](https://github.com/Rac-ice/ASP.NET-Learning/assets/56425821/3db4949a-2368-4a8e-9f85-ec2d965bc83c)


## 三层架构与MVC

![image](https://github.com/Rac-ice/ASP.NET-Learning/assets/56425821/d6be2f50-3a54-45e0-b1ec-4940120bc291)


## ASP.Net的两种开发方式

- WebForm的开发方式
    - 服务器端控件
    - 一般处理程序+Html静态页+Ajax
    - 一般处理程序+Html模板
- ASP.Net MVC的开发方式
    - 更接近原始的“请求-处理-响应”
    - 底层跟WebForm是一样的，管道上进行不同处理

![image](https://github.com/Rac-ice/ASP.NET-Learning/assets/56425821/45b337ec-a8e3-4f93-a961-d074b1aeb800)


### `Asp.Net MVC`请求模型

![image](https://github.com/Rac-ice/ASP.NET-Learning/assets/56425821/49fb322e-b535-4db9-a0ba-b2a8dfc228c1)

### `WebForm`模型

![image](https://github.com/Rac-ice/ASP.NET-Learning/assets/56425821/2969025f-0bed-4e5b-8d55-48d7cabce1d9)


## HtmlHelper详解

```csharp
<a href="<%: Url.Action("Index","UserInfo") %>">UrlHelper生成的url地址</a>
<%-- <a href="/UserInfo">UrlHelper生成的url地址</a> --%>
<%: Html.ActionLink("超链接文本","index","UserInfo") %>
<%--  <a href="/UserInfo">超链接文本</a> --%>
<%: Html.ActionLink("超链接文本", "index", "UserInfo", new { name = "test",age=19 }, new { demo="sss" })%>
<%-- <a demo="sss" href="/UserInfo?name=test&amp;age=19">超链接文本</a> --%>
```

```csharp
<%: Html.TextBox("UserName","hello") %>
<%-- <input id="UserName" name="UserName" type="text" value="hello" /> --%>
<%: Html.CheckBox("Foot",true) %>
<%-- <input checked="checked" id="Foot" name="Foot" type="checkbox" value="true" /><input name="Foot" type="hidden" value="false" /> --%>
<%: Html.TextArea("Content","UrlHelper生成文本域") %>
<%-- <textarea cols="20" id="Content" name="Content" rows="2">UrlHelper生成文本域</textarea> --%>
```

```csharp
ViewData["City"] = new List<SelectListItem>()
{
    new SelectListItem(){Selected=false,Text="北京",Value="1"},
    new SelectListItem(){Selected=true,Text="上海",Value="2"},
    new SelectListItem(){Selected=false,Text="广州",Value="3"}
};
ViewData["demo"] = "hello";
<%: Html.DropDownList("City") %>
<%--<select id="City" name="City">
    <option value="1">北京</option>
    <option selected="selected" value="2">上海</option>
    <option value="3">广州</option>
</select>--%>
<%: Html.TextBox("demo") %>
<%--<input id="demo" name="demo" type="text" value="hello" />--%>
```

```csharp
男<%: Html.RadioButton("Gender","1",false) %>
女<%: Html.RadioButton("Gender","2",true) %>
<%--男<input id="Gender" name="Gender" type="radio" value="1" />
女<input checked="checked" id="Gender" name="Gender" type="radio" value="2" />--%>
```

## 强类型视图

在第一行中，把动态数据类型换成指定的数据类型，比如：`System.Web.Mvc.ViewPage<MvcUserDemo.Models.UserInfo>` ，然后在控制器中传递该数据类型的值，View中只能该数据的值，称为强类型视图

### 请类型HtmlHelper用法

```csharp
UserInfo userInfo = new UserInfo();
userInfo.Id = 9;
userInfo.UserName = "test";
userInfo.Age = 18;
ViewData.Model = userInfo;
<%: Html.TextBoxFor(u=>u.UserName) %>//强类型
<%--<input id="UserName" name="UserName" type="text" value="test" />--%>
<%: Html.TextBox("Age") %>
<%--<input data-val="true" data-val-number="字段 Age 必须是一个数字。" data-val-required="Age 字段是必需的。" id="Age" name="Age" type="text" value="18" />--%>
```

## Html.Encode

- <%: %> 相当于 <%= Html.Encode()%>
- 推荐使用<%: %>，=：原封不动的输出字符串，:：对字符串进行编码后再输出
- 输出特殊字符 比如 <script>
    - HtmlString 和 MvcHtmlString
    - Html.Raw()

```csharp
<%: ViewData["strScript"] %>
<%-- : &lt;script&gt;alert(&#39;demo&#39;);&lt;/script&gt; --%>
<%= ViewData["strScript"] %>
<%-- = <script>alert('demo');</script> --%>
<%:Html.Raw("<p>hello</p>") %>
<%: new HtmlString("<p>hello</p>") %>
<%: new MvcHtmlString("<p>hello</p>") %>
<%-- <p>hello</p> --%>
```

## htmlHelper扩展

- 扩展方法三要素：静态类、静态方法、this关键字
    
    ```csharp
    public static class MyHtmlHelperExt
    {
        public static string MyLabel(this HtmlHelper helper, string txt)
        {
            return string.Format("<span>{0}</span>", txt);
        }
    }
    ```
    
- 解决返回的标签被HtmlEncode的问题
    
    ```csharp
    //法一
    <%: Html.Raw(Html.MyLabel("test")) %>//麻烦，与微软提供的封装方法效果不符
    //法二
    public static class MyHtmlHelperExt
    {
        public static string MyLabel(this HtmlHelper helper, string txt)
        {
            return string.Format("<span>{0}</span>", txt);
        }
    
        public static HtmlString MyHtmlStringLabel(this HtmlHelper helper, string txt)
        {
            return new HtmlString(string.Format("<span>{0}</span>", txt));
        }
    }
    <%: Html.MyHtmlStringLabel("test") %>//与微软提供的方法效果大致相同，缺点要引用命名空间
    ```
    
- 解决引用命名空间问题：直接把扩展方法的命名空间改为HtmlHelper的命名空间System.Web.Mvc，然后生成，这样就能在任意页面使用该封装方法

## Razor引擎语言

### Razor语句块

- 使用@{code}来定义一段代码块
- Razor支持代码混写，在代码块中插入HTML、在HTML中插入Razor语句都是可以的

### Razor页面上输出特殊字符串

- 输出原生的字符串：@Html.Raw(html)
- HtmlString类型和MvcHtmlString类型字符串输出

```csharp
@{
    string str = "<script>alert('haha')</script>";
    <p>@str</p>
}
//<p>&lt;script&gt;alert(&#39;haha&#39;)&lt;/script&gt;</p>
@Html.Raw("<script>alert('haha')</script>")
//<script>alert('haha')</script>
```

### Razor引擎的转换数据类型

![image](https://github.com/Rac-ice/ASP.NET-Learning/assets/56425821/2377ca07-1ec9-4b48-8b86-17ac55637801)


## 控制器详解

- 控制器三个职责：处理跟用户的交互、处理业务逻辑的调用、指定具体的视图显示数据，并且把数据传递给视图
- 控制器的约定：必须实现IController接口、必须以Controller为结尾、必须非静态类
- 在Action中可以访问HttpContext中所有的相关数据，Session、Cookie等

## 深入Routing

- Routing的作用
    - 确定Controller
    - 确定Action
    - 确定其他参数
    - 根据识别出来的数据，将请求传递给Controller和Action

![image](https://github.com/Rac-ice/ASP.NET-Learning/assets/56425821/6a5c3a5e-c3b3-4cd0-a40a-3f7ef506b1bd)


- 路由规则
    - 可以有多条路由规则
    - 路由规则是有顺序的，前面被匹配了之后，后面就没有机会了

## Url路由实例讲解

- 对于一个网站，为了SEO友好，一个网址的URL层次不要超过三层
- localhost/{频道}/{具体网页}
- 其中域名第一层，频道第二层，最后的网页就是最后一层，如果使用默认实例中的”{controller}/{action}-{其他参数}”的形式会影响网站的SEO

![路由规则书写顺序由最子项到全能匹配]![image](https://github.com/Rac-ice/ASP.NET-Learning/assets/56425821/5c5cc61a-1ff0-485a-89dc-23f49300173e)


路由规则书写顺序由最子项到全能匹配

## MVC验证

- .NET框架中包含了多个内置验证特性，其中最常用的四个：[Required]、[StringLength]、[Range]、[RegularExpression]
- 可以根据自己需要定义自己的定制验证特性
    
    ```csharp
    public int Id { get; set; }
    [StringLength(5,ErrorMessage="*长度必须<5")]
    [Required(ErrorMessage="*必填姓名")]
    public string UserName { get; set; }
    [RegularExpression(@"\d+$")]
    [Range(1,120)]
    [Required(ErrorMessage="*")]
    public int Age { get; set; }
    ```
    
- 服务器端校验只需要在Action中校验：Model.IsValidate属性即可，true就是校验通过，false反之不通过
    
    ```csharp
    if (ModelState.IsValid){ }
    ```
    
- 要使用客户端验证，必须引入JS脚本支持（jquery的校验）
    
    ```csharp
    <script src="~/Scripts/jquery-1.8.2.js"></script>
    <script src="~/Scripts/jquery.validate.js"></script>
    <script src="~/Scripts/jquery.validate.unobtrusive.js"></script>
    ```
    
- 添加语句：<% Html.EnableClientValidation();%>(MVC3、4中默认开启)
    
    ```csharp
    @{ Html.EnableClientValidation();//默认true，值为true或false }
    ```
    
- WebConfig中可以设置全局客户端校验是否开启或者关闭
    
    ```csharp
    <appSettings>
      <add key="webpages:Version" value="2.0.0.0" />
      <add key="webpages:Enabled" value="false" />
      <add key="PreserveLoginUrl" value="true" />
      <add key="ClientValidationEnabled" value="true" />
      <add key="UnobtrusiveJavaScriptEnabled" value="true" />
    </appSettings>
    ```
    

## AspNet MVC下的Ajax

- 使用jquery做相关的Ajax请求
    
    ```csharp
    $.ajax({
        url: "/Ajax/GetDate",
        type: "post",
        success: function (data) {
            alert(data);
        },
        data:"id=2&name=222"
    });
    $.get("/Ajax/GetDate", {}, function (data) {
        alert(data);
    });
    ```
    
- 使用微软提供的Ajax请求脚本
    
    ```csharp
    <script src="~/Scripts/jquery-1.8.2.js"></script>
    <script src="~/Scripts/jquery.unobtrusive-ajax.js"></script>
    <script type="text/javascript">
        function afterSuccess(data) {
            alert(data);
        }
    </script>
    @using (Ajax.BeginForm("GetDate", "Ajax", new AjaxOptions() 
    { Confirm = "您是否要提交吗？", HttpMethod = "post", 
    InsertionMode = InsertionMode.Replace, UpdateTargetId = "result", 
    OnSuccess = "afterSuccess", LoadingElementId = "loading" }))
    {
        <div>
            用户名：<input type="text" name="UserName" /><br />
            密码：<input type="password" name="Pwd" /><br />
            <input type="submit" value="提交" />
        </div>
    }
    <div id="result">
    </div>
    <div id="loading" style="display:none">
        <div style="background-color:red;width:50px;height:50px"></div>
    </div>
    ```
    

## 过滤器详解

在大一些的项目中，会出现一些AOP面向切片的组件，在Asp.Net MVC项目中，想要做一些特殊操作（如身份验证、日志、异常、行为截取等），不需要我们自己实现复杂的AOP，Asp.Net MVC为我们提供了Filter，我们可以直接使用Filter特性实现这些操作

- AttributeUsage特性用于设置标签
- Gloable Filte允许我们设置全局过滤器
- 异常过滤器：当我们Mvc站点出现了异常的时候会自动执行异常过滤器里面的方法

### 微软提供的默认的过滤器

![image](https://github.com/Rac-ice/ASP.NET-Learning/assets/56425821/82d2ec56-3753-4804-906c-9479df64341d)


- 作用到Action的过滤器，优先级最高
    
    ```csharp
    [MyActionFilter(Name="Index Action")]
    public ActionResult Index()
    {
        Response.Write("<p>Action执行了</p>");
    
        return Content("<br />ok:视图被渲染<br />");
    }
    ```
    
- 作用到Controller的过滤器，该控制器内的Action都能过滤
    
    ```csharp
    [MyActionFilter(Name = "Index Action")]
    public class HomeController : Controller
    ```
    
- 全局过滤器，优先级最低，但是可以作用到所有的控制器和action
    
    ```csharp
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //全局过滤器，优先级最低，但是可以作用到所有的控制器和action
            filters.Add(new MyActionFilterAttribute());
        }
    }
    ```
    
- 允许多个标签同时都起作用，在自定义的过滤器上加上特性
    
    ```csharp
    [AttributeUsage(AttributeTargets.All,AllowMultiple=true)]
    public class MyActionFilterAttribute : ActionFilterAttribute
    {
        public string Name { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            HttpContext.Current.Response.Write("<br />OnActionExecuting :"+Name);
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            HttpContext.Current.Response.Write("<br />OnActionExecuted :" + Name);
        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
            HttpContext.Current.Response.Write("<br />OnResultExecuting :" + Name);
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
            HttpContext.Current.Response.Write("<br />OnResultExecuted :" + Name);
        }
    }
    ```
    
- 异常过滤器
    
    ```csharp
    public class MyExceptionFilterAttrbute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
    
            //当出现异常的时候，才执行此方法
    
            //记录日志
            //多个线程同时访问同一个日志文件
            //性能非常低
            //考虑使用内存队列提高性能，Redis
            //加入观察者模式屏蔽写入不同地方的变化点
            //log4net
    
            //页面跳转到错误页面或者是首页
            HttpContext.Current.Response.Redirect("/Home/Index");
        }
    }
    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
        filters.Add(new MyExceptionFilterAttrbute());
    }
    ```
    

## 区域详解

- Asp.Net Mvc提供了区域的功能，可以为大型的网站划分区域
- 每个模块的页面都放入相应的区域内进行管理
- 区域功能类似一个小的MVC项目，有自己的控制器、模型、试图、路由设置
- 区域的路由设置是最优先的

## WebAPI

- WebService和WCF复杂不够灵活
- WebAPI：轻巧、方便、是Http请求

### Ajax请求WebAPI

![image](https://github.com/Rac-ice/ASP.NET-Learning/assets/56425821/239f115d-b99e-41f0-a007-673678c9c161)

