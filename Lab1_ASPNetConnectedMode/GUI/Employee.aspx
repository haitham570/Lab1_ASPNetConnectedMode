<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="Lab1_ASPNetConnectedMode.GUI.Employee"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 60%;
            height: 319px;
            margin-top: 3px;
            margin-bottom: 317px;
            margin-left: 3px;
            position: absolute;
            left: 45px;
            top: 73px;
            margin-right: 224px;
        }
        .auto-style28 {
            width: 174px;
            height: 39px;
        }
        .auto-style29 {
            width: 174px;
        }
        .auto-style32 {
            width: 15px;
            height: 39px;
        }
        .auto-style33 {
            width: 15px;
        }
        .auto-style34 {
            width: 104px;
            height: 39px;
        }
        .auto-style35 {
            width: 104px;
        }
        .auto-style40 {
            width: 27px;
            height: 39px;
        }
        .auto-style41 {
            width: 27px;
        }
        .auto-style42 {
            text-align: center;
            margin-left: 40px;
        }
        .auto-style49 {
            height: 35px;
        }
        .auto-style50 {
            width: 104px;
            height: 65px;
        }
        .auto-style51 {
            width: 27px;
            height: 65px;
        }
        .auto-style52 {
            width: 15px;
            height: 65px;
        }
        .auto-style53 {
            width: 174px;
            height: 65px;
        }
        .auto-style54 {
            width: 929px;
            height: 200px;
            position: absolute;
            left: 50px;
            top: 417px;
            right: 578px;
        }
        .auto-style56 {
            text-align: left;
            color: #FF9900;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style42">
            <div class="auto-style49">
                <h1 class="auto-style56"><strong>Employees Maintenance</strong></h1>
                <br />
            </div>
            <table class="auto-style1" align="center">
                <tr>
                    <td class="auto-style34">Employee ID</td>
                    <td class="auto-style40">
                        <asp:TextBox ID="TextBoxEmployeeID" runat="server" Width="176px"></asp:TextBox>
                    </td>
                    <td class="auto-style32"></td>
                    <td class="auto-style28">
                        <asp:Button ID="ButtonSaveEmployee" runat="server" Text="Save Employee" Width="145px" OnClick="ButtonSaveEmployee_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style35">First Name:</td>
                    <td class="auto-style41">
                        <asp:TextBox ID="TextBoxFirstName" runat="server" Width="176px"></asp:TextBox>
                    </td>
                    <td class="auto-style33">&nbsp;</td>
                    <td class="auto-style29">
                        <asp:Button ID="ButtonUpdateEmployee" runat="server" Text="Update Employee" Width="144px" OnClick="ButtonUpdateEmployee_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style35">Last Name:</td>
                    <td class="auto-style41">
                        <asp:TextBox ID="TextBoxLastName" runat="server" Width="178px"></asp:TextBox>
                    </td>
                    <td class="auto-style33">&nbsp;</td>
                    <td class="auto-style29">
                        <asp:Button ID="ButtonListAllEmployees" runat="server" Text="List All" Width="147px" OnClick="ButtonListAllEmployees_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style35">
                        Job Title</td>
                    <td class="auto-style41">
                        <asp:TextBox ID="TextBoxJobTitle" runat="server" Width="177px"></asp:TextBox>
                    </td>
                    <td class="auto-style33">&nbsp;</td>
                    <td class="auto-style29">
                        <asp:Button ID="ButtonDeleteEmployee" runat="server" Text="Delete Employee" Width="146px" OnClick="ButtonDeleteEmployee_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style50">Search by : </td>
                    <td class="auto-style51">
                        <asp:DropDownList ID="DropDownListSearchBy" runat="server" Width="182px" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style52">
                        <asp:TextBox ID="TextBoxSearchBy" runat="server" Width="187px"></asp:TextBox>
                    </td>
                    <td class="auto-style53">
                        <asp:Button ID="ButtonSearch" runat="server" Text="Search" Width="146px" OnClick="ButtonSearch_Click" />
                    </td>
                </tr>
                
                </table>
        </div>
        <asp:GridView ID="GridView1" runat="server" CssClass="auto-style54">
        </asp:GridView>
    </form>
</body>
</html>
