<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditStudent.aspx.cs" Inherits="FirstAttempt.EditStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        .auto-style1 {
            width: 100%;
            height: 294px;
        }
        .auto-style6 {
            height: 23px;
            width: 198px;
        }
        .auto-style2 {
            height: 23px;
        }
        .auto-style5 {
            height: 24px;
            width: 198px;
        }
        .auto-style3 {
            height: 24px;
        }
        </style>
</head>
<body>
    <form id="form2" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td colspan="2" style="text-align: center">
                    <asp:Label ID="Label9" runat="server" style="font-weight: 700; font-size: xx-large; font-style: italic; text-align: center" Text="Edit Student Informations"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="Label1" runat="server" Text="Student Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbStudentName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfStudentName" runat="server" ControlToValidate="tbStudentName" ErrorMessage="Please Enter Your Name">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <asp:Label ID="Label2" runat="server" Text="Teacher ID"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:DropDownList ID="ddlTeacherID" runat="server" Height="17px" Width="71px">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">
                    <asp:Label ID="Label3" runat="server" Text="Grade"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:DropDownList ID="ddlGrade" runat="server">
                        <asp:ListItem>1st Grade</asp:ListItem>
                        <asp:ListItem>2nd Grade</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <asp:Label ID="Label4" runat="server" Text="Address"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="tbAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <asp:Label ID="Label5" runat="server" Text="City"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="tbCity" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="Label6" runat="server" Text="Zip Code"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbZipCode" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="zipcoderegularexpression" runat="server" ControlToValidate="tbZipCode" ErrorMessage="ZipCode format is wrong" ValidationExpression="\d{5}(-\d{4})?"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="Label7" runat="server" Text="State"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlState" runat="server">
                        <asp:ListItem>Texas</asp:ListItem>
                        <asp:ListItem>Alabama</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="Label8" runat="server" Text="Total Marks"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tbTotalMarks" runat="server"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="tbTotalMarks" ErrorMessage="Total Marks must be between 0-500" MaximumValue="500" MinimumValue="0"></asp:RangeValidator>
                    <asp:HiddenField ID="hfMarks" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="auto-style4" colspan="2">
                    <asp:Button ID="btnUpdateStudent" runat="server" OnClick="btnUpdateStudent_Click" Text="Update Student Info" />
                    <asp:Button ID="Button2" runat="server" Text="Cancel" />
                    <br />
                    <br />
                    <asp:Label ID="lblResult" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Click to Check the list of students</asp:HyperLink>
                    <br />
                    <br />
                    <asp:ValidationSummary ID="studentformvalidationsummary" runat="server" BorderStyle="Outset" ForeColor="#009900" ShowMessageBox="True" />
                    <br />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
    
</body>
</html>
