var table = $('#tableContact').DataTable({
    // DataTable initialization options
    searching: false
});

$(document).ready(function () {
    //$('#tableContact').DataTable({});


});
function search(wide) {

    var obj = {};

    obj.isWideSearch = wide;
    obj.searchValue = $("#SearchValue").val();
    if (!wide) {
        obj.firstName = $("#FirstName").val();
        obj.lastName = $("#LastName").val();
        obj.middleName = $("#MiddleName").val();
        obj.email = $("#Email").val();
        obj.lineNbr = $("#Number").val();

        if ($("#YOB").val() != "") {
            obj.dob = $("#YOB").val();
        } else {
            obj.dob = null;
        }
    }
    var formBody = new FormData();
    formBody.append("contact", JSON.stringify(obj));
    $.ajax({
        url: "../Contact/Search",
        type: "POST",
        //contentType: "application/json",
        contentType: false,
        processData: false,
        data: formBody,
        beforeSend: function (xhr) {
            showLoading();
            xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem('jwt'));
        },
        success: function (data) {
            hideLoading();
            // create an empty array to hold the data
            var dataTableData = [];
            var dataTableData = data.contact;

            //Destroy
            $('#tableContact').DataTable().destroy();

            // initialize DataTables with the data
            table = $('#tableContact').DataTable({
                data: dataTableData,
                processing: true,
                responsive: true,
                autoWidth: false,
                language: {
                    processing: '<i class="fa fa-spinner fa-spin"></i> Loading...'
                },
                columns: [
                    {
                        "data": null,
                        "render": function (data, type, row) {
                            return data.firstName + ' ' + data.middleName + ' ' + data.lastName;
                        }
                    },
                    { data: 'description' },
                    { data: 'yob' },
                    { data: 'company' },
                    { data: 'job' },
                    { data: 'recId' }
                ],
                columnDefs: [{
                    targets: -1, // The last column in the table

                    data: null,
                    render: function (data, type, row, meta) {
                        // Use the Font Awesome edit icon
                        var params = encodeParameters("?contactId=" + row.recId);
                        var html = '<a href="../Contact/edit/' + row.recId + '" title="Edit Contact" ><i class="fas fa-edit"></i></a> <a href="../transaction/Dashboard/' + params + '" title="Create Transaction"><i class="fas fa-plus"></i></a>';
                        return html;
                    }
                }
                ],
            });

        },
        error: function (xhr, status, error) {
            console.log("Error: " + error);
        }
    });
}

$("#btnSearch").click(function (e) {
    search();
})

$("#btnAddWizard").click(function (e) {
    var firstName = $("#FirstName").val();
    var lastName = $("#LastName").val();
    var middleName = $("#MiddleName").val();
    var email = $("#Email").val();
    var lineNbr = $("#Number").val();
    var dob = $("#YOB").val();
    if (firstName == null && lastName == null && middleName == null && email == null && lineNbr == null && dob == null) {
        window.location.href = "../contact/create?firstName=&lastName=&middleName=&email=&lineNbr=&dob=";
    } else {
        window.location.href = "../contact/create?firstName=" + firstName + "&lastName=" + lastName + "&middleName=" + middleName + "&email=" + email + "&lineNbr=" + lineNbr + "&dob=" + dob
    }

})

$('#tableContact tbody').on('click', 'tr', function () {
    // Get the data for the selected row
    var rowData = table.row(this).data();

    // alert(rowData.firstName)
    // Display the details in a separate section or modal
    //$('#detailsName').text(rowData.name);
    //$('#detailsEmail').text(rowData.email);
    //$('#detailsPhone').text(rowData.phone);
    // ... and so on for all other details
});
//const myForm = document.getElementById("formSearch");

$("#formSearch").on("blur", "input", function (event) {
    // Use a timeout to wait for the user to finish typing

    if ($(this).attr("name") == "WideSearch") {
        search(true);
    } else {
        search();
    }

    //setTimeout(() => {
    //    // Do something when an input loses focus
    //    console.log("Input lost focus:", $(this).attr("name"));
    //}, 500); // Adjust the timeout duration as needed
});
//$(document).on('keypress', function (event) {
//    if (event.key === 'Enter') {
     //search(true);
//        var obj = {};

//        obj.isWideSearch = true;
//        obj.searchValue = $("#SearchValue").val();
//        var formBody = new FormData();
//        formBody.append("contact", JSON.stringify(obj));
//        $.ajax({
//            url: "/Contact/Search",
//            type: "POST",
//            //contentType: "application/json",
//            contentType: false,
//            processData: false,
//            data: formBody,
//            beforeSend: function (xhr) {
//                showLoading();
//                xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem('jwt'));
//            },
//            success: function (data) {
//                hideLoading();
//                // create an empty array to hold the data
//                var dataTableData = [];
//                var dataTableData = data.contact;

//                //Destroy
//                $('#tableContact').DataTable().destroy();

//                // initialize DataTables with the data
//                table = $('#tableContact').DataTable({
//                    data: dataTableData,
//                    processing: true,
//                    responsive: true,
//                    autoWidth: false,
//                    language: {
//                        processing: '<i class="fa fa-spinner fa-spin"></i> Loading...'
//                    },
//                    columns: [
//                        {
//                            "data": null,
//                            "render": function (data, type, row) {
//                                return data.firstName + ' ' + data.middleName + ' ' + data.lastName;
//                            }
//                        },
//                        { data: 'description' },
//                        { data: 'yob' },
//                        { data: 'company' },
//                        { data: 'job' },
//                        { data: 'recId' }
//                    ],
//                    columnDefs: [{
//                        targets: -1, // The last column in the table

//                        data: null,
//                        render: function (data, type, row, meta) {
//                            // Use the Font Awesome edit icon
//                            var params = encodeParameters("?contactId=" + row.recId);
//                            var html = '<a href="../Contact/edit/' + row.recId + '" title="Edit Contact" ><i class="fas fa-edit"></i></a> <a href="../transaction/Dashboard/' + params + '" title="Create Transaction"><i class="fas fa-plus"></i></a>';
//                            return html;
//                        }
//                    }
//                    ],
//                });

//            },
//            error: function (xhr, status, error) {
//                console.log("Error: " + error);
//            }
//        });

//    }
//});
function searchContactByNumber(number) {

    var obj = {};
    obj.isWideSearch = false;
    obj.lineNbr = number;
    var formBody = new FormData();
    formBody.append("contact", JSON.stringify(obj));
    $.ajax({
        url: "../Contact/Search",
        type: "POST",
        //contentType: "application/json",
        contentType: false,
        processData: false,
        data: formBody,
        beforeSend: function (xhr) {
            showLoading();
            $("#txtContactMobileInfo").show();
            $("#txtContactMobileInfo").html("");
            xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem('jwt'));
        },
        success: function (data) {
            hideLoading();
            // create an empty array to hold the data
            var dataTableData = [];
            var dataTableData = data.contact;
            if (dataTableData.length != null && dataTableData.length != 0) {
               // var params = encodeParameters("?contactId=" + row.recId);
               // var html = '<a href="../Contact/edit/' + row.recId + '" title="Edit Contact" ><i class="fas fa-edit"></i></a>';
                $("#txtContactMobileInfo").show();
                $("#txtContactMobileInfo").html("");
                var html = "<b>This Number is related: [" + number + "]</b>\n";
                html += "<ul>";
                for (var i = 0; i < dataTableData.length; i++) {
                    html += '<li><a href="../Contact/edit/' + dataTableData[i].recId + '" title=' + dataTableData[i].firstName + " " + dataTableData[i].middleName + " " + dataTableData[i].lastName + ' >' + dataTableData[i].firstName + " " + dataTableData[i].middleName + " " + dataTableData[i].lastName + '</a> </li>';
                }
                html += "</ul>";
            }
            $("#txtContactMobileInfo").html(html);
        },
        error: function (xhr, status, error) {
            console.log("Error: " + error);
            $("#txtContactMobileInfo").html("");
            $("#txtContactMobileInfo").hide();
        }
    });
    // return null;
}