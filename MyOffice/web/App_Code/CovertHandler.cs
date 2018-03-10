using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Drawing;

/// <summary>
/// CovertHandler 的摘要说明
/// </summary>
public class CovertHandler:IHttpHandler
{
    public CovertHandler()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    private const string WATERMARK_URL = "~/Images/Users/WaterMark.png";
    private const string DEFAULTMARK_URL = "~/Images/Users/noperson.jpg";
    public void ProcessRequest(HttpContext context)
    {
        System.Drawing.Image Cover;
        //判断请求的物理路径，是否存在文件
        if (File.Exists(context.Request.PhysicalPath))
        {
            //加载文件
            Cover = System.Drawing.Image.FromFile(context.Request.PhysicalPath);
            //加载水印图片
            System.Drawing.Image watermark =
                System.Drawing.Image.FromFile(context.Request.MapPath(WATERMARK_URL));
            //实例化画布
            try
            {
                Graphics g = Graphics.FromImage(Cover);
                //在Cover上绘制水印
                //if (Cover.Width > 150 && Cover.Height > 180)
                //{
                   // Cover.Width = 160;
                   // Cover.Height = 177;
                    //先第一次是原有图片的属性  第二次就是800 100 操控了第一次又不能左右 第二次的  。。
                    //g.DrawImage(watermark, new Rectangle(Cover.Width - 1000,
                    //   Cover.Height - 650, 1000, 650),
                    // 0, 0, 1000, 650, GraphicsUnit.Pixel);
                //}
                //else
                //{
                    g.DrawImage(watermark, new Rectangle(Cover.Width - watermark.Width,
                        Cover.Height - watermark.Height, watermark.Width, watermark.Height),
                        0, 0, watermark.Width, watermark.Height, GraphicsUnit.Pixel);
                //}
                //释放画布
                g.Dispose();
                //释放水印图片
                watermark.Dispose();
            }catch(Exception ex)
            {
                ex.Message.ToString();
                Cover = System.Drawing.Image.FromFile(context.Request.MapPath(DEFAULTMARK_URL));

            }
           
           
        }
        else
        { 
            //加载默认图片
            Cover = System.Drawing.Image.FromFile(context.Request.MapPath(DEFAULTMARK_URL));
        }
        //设置输出格式
        context.Response.ContentType = "image/jpeg";
        //将图片存入输出流
        Cover.Save(context.Response.OutputStream,System.Drawing.Imaging.ImageFormat.Jpeg);
        Cover.Dispose();
        context.Response.End();
    }
    public bool IsReusable
    {
        get 
        {
            return false;
        }
    }
}
