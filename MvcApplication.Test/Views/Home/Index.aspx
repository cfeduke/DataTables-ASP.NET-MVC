<%@ Page Title="" Language="C#" MasterPageFile="~/Views/ViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<script type="text/javascript">
    $(document).ready(function () {
        //http://www.datatables.net
        $('#userTable').dataTable({
            "sDom": "rt",
            "bJQueryUI": true,
            "sPaginationType": "full_numbers",
            "bProcessing": true,
            "bServerSide": true,
            "sAjaxSource": "/Home/GetDataTables",
            "fnServerData": function (url, data, callback) {
                $.ajax({
                    "url": url,
                    "data": data,
                    "success": callback,
                    "contentType": "application/x-www-form-urlencoded; charset=utf-8",
                    "dataType": "json",
                    "type": "POST",
                    "cache": false,
                    "error": function () {
                        alert("DataTables warning: JSON data from server failed to load or be parsed. " +
						"This is most likely to be caused by a JSON formatting error.");
                    }
                });
            },
            "aoColumns": [
                {"bSortable": true},
                {"bSortable": true}
            ]
        });
    });                    
</script>

<table id="userTable" width="100%">
    <thead>
        <tr>
            <th>Number</th>
            <th>Text</th>
        </tr>
    </thead>
    <tbody></tbody>
    <tfoot></tfoot>
</table>

</asp:Content>
