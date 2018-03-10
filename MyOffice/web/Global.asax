<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // 在应用程序启动时运行的代码

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  在应用程序关闭时运行的代码

    }
        
    void Application_Error(object sender, EventArgs erroy) 
    {
       
    }

    void Session_Start(object sender, EventArgs e) 
    {
       if (((MyOffice.Models.User)Session["Login"])==null)
       {
           Response.Redirect("~/Login.aspx");
       }
    }

    void Session_End(object sender, EventArgs e) 
    {
        string b = "";
    }
       
</script>
