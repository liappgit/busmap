using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
///WebService 的摘要说明
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
//若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService {

    public WebService () {

        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string convertToChinese(int money)
    {
        string[] digits = { "零", "壹", "贰", "叁", "肆", "伍", "陆", "柒", "捌", "玖" };
        int qian, bai, shi, ge;
        qian = money / 1000;
        bai = money % 1000 / 100;
        shi = money % 100 / 10;
        ge = money % 10;
        string result = "";
        if (qian > 0)
            result += digits[qian] + "仟";
        if (bai > 0)
            result += digits[bai] + "佰";
        if (shi > 0)
            result += digits[shi] + "拾";
        if (ge > 0)
            result += digits[ge];
        result += "元整";
        return result;
    }
    
}
