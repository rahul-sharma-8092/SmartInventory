$(document).ready(function () {
    BindCategories();
});

const BindCategories = () => {
const storeUserName = $("#hdnStoreUserName").val();
    $("#categoryGrid").kendoGrid({
        dataSource: {
            transport: {
                read: {
                    url: `/Home/Handler/Setting.ashx?RequestType=1&StoreUserName=${storeUserName}`, // GetCategories - URL to fetch categories from the server
                    dataType: "json"
                }
            },
            pageSize: 10,
            schema: {
                model: {
                    id: "CategoryID",
                    fields: {
                        CategoryID: { type: "number" },
                        CategoryName: { type: "string" },
                        Description: { type: "string" },
                        ParentName: { type: "string" },
                        IsActive: { type: "string" },
                        CreatedAT: { type: "date" }
                    }
                }
            }
        },
        columns: getColumnList(),
        dataBound: onGridDataBound,
        pageable: true,
        sortable: true,
        toolbar: ["excel", "pdf"],
        excel: {
            fileName: "Categories.xlsx",
            filterable: true
        },
        pdf: {
            fileName: "Categories.pdf"
        }
    });
}

const getColumnList = () => {
    const colList = [
        { field: "CategoryID", title: "ID", width: "80px" },
        { field: "CategoryName", title: "Category Name", width: "200px" },
        { field: "Description", title: "Description", width: "300px" },
        { field: "ParentName", title: "Parent Name", width: "300px" },
        { field: "IsActive", title: "Status", width: "100px", },
        { field: "CreatedAT", title: "Created Date", format: "{0:MM/dd/yyyy}", width: "150px" },
        {
            command: [
                {
                    name: "delete",
                    text: "Delete",
                    click: deleteCategory,
                }
            ],
            title: "Actions", width: "120px"
        }
    ]

    return colList;
}

function onGridDataBound(e) {
    const grid = this;
    const storeUserName = $("#hdnStoreUserName").val();

    grid.tbody.find("tr").on("dblclick", function () {
        const dataItem = grid.dataItem(this);
        if (dataItem) {
            window.location.href = `/${storeUserName}/Home/Settings/AddUpdateCategories.aspx?Id=${encodeURI(dataItem.CategoryID)}`;
        }
    });
}

const deleteCategory = (e) => {
    const storeUserName = $("#hdnStoreUserName").val();
    const dataItem = $("#categoryGrid").data("kendoGrid").dataItem($(e.target).closest("tr"));
    const categoryId = dataItem.CategoryID;

    if (confirm("Are you sure you want to delete this category?")) {
        $.ajax({
            url: `/Home/Handler/Setting.ashx?RequestType=2&StoreUserName=${storeUserName}`,
            type: 'POST',
            contentType: 'application/json',
            dataType: 'json',
            data: JSON.stringify({ id: categoryId }),
            success: function (response) {
                console.log(response);
                if (response.success) {
                    showNotification(response.data, 'success');
                }
                else {
                    showNotification(response.data, 'error');
                }
                $("#categoryGrid").data("kendoGrid").dataSource.read();
            },
            error: function (e) {
                console.log(e);
                showNotification('Error deleting category.', 'error');
            }
        });
    }
};