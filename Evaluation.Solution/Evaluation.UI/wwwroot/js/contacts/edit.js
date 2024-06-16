
$(document).ready(function () {
   
    for (var i = 0; contactChannel.length > i; i++) {
     
        var objTo = document.getElementById("ChannelListView");
        var divtest = document.createElement("div");
        divtest.setAttribute("class", "mb-3 removeclass" + room);

        var selectChannelHtml = "<select id='ddlChannel" + room + "' required name='ddlChannel" + room + "' data-count='" + room + "' class='selectChannel select2 form-select required' >";
        selectChannelHtml += "<option value=''>--Select--</option>";
        for (var y = 0; channelsList.length > y; y++) {
            if (contactChannel[i].code == channelsList[y].code) {
               selectChannelHtml += "<option value='" + channelsList[y].code + "' selected data-type='" + channelsList[y].type + "'>" + channelsList[y].description + "</option>";
            } else {
            selectChannelHtml += "<option value='" + channelsList[y].code + "' data-type='" + channelsList[y].type + "'>" + channelsList[y].description + "</option>";
            }

        }
        selectChannelHtml += "</select>";



        var html = '<div class="row" data-count="' + room + '" >' +
            '    <div class="col-sm-3">' +
            '        <div class="mb-3">' +
            selectChannelHtml +
            '        </div>' +
            '<input type="hidden"  id="RecId' + room + '" name="RecId' + room + '" value="' + contactChannel[i].recId + '">' +
            '    </div>';
        if (contactChannel[i].type == "Phone") {
            html +=
                //'    <div class="col-sm-2 phoneElement' + room + ' ">' +
                //'        <div class="mb-3">' +

                //'<input type="number" class="form-control required" id="CountryCode' + room + '" name="CountryCode' + room + '" placeholder="Country Code" value="' + contactChannel[i].countryCode + '" >' +
                //'        </div>' +
                //'    </div>' +
                //'    <div class="col-sm-2 phoneElement' + room + ' ">' +
                //'        <div class="mb-3">' +
                //'<input type="number" class="form-control required" id="AreaCode' + room + '" name="AreaCode' + room + '" placeholder="Area Code" value="' + contactChannel[i].areaCode + '">' +
                //'        </div>' +
                //'    </div>' +
              
                '    <div class="col-sm-2 phoneElement' + room + ' " >' +
                '        <div class="mb-3">' +
            '            <input type="number" class="form-control required"  required id="txtChannelValuePhone' + room + '" name="txtChannelValuePhone' + room + '"value="' + contactChannel[i].contactChannelValue + '" placeholder="Ex: +961 71776614"/>' +
                '        </div>' +
                '    </div>'+
            '    <div class="col-sm-2 phoneElement' + room + ' ">' +
                '        <div class="mb-3">' +
                '<input type="number" class="form-control " id="Extension' + room + '" name="Extension' + room + '" placeholder="Extension" value="' + contactChannel[i].extension + '">' +
                '        </div>' +
                '    </div>' ;
        } else {
            html += '    <div class="col-sm-4 emailElement' + room + '" >' +
                '        <div class="mb-3">' +
                '            <input type="email" class="form-control required" required id="txtChannelValueEmail' + room + '" name="txtChannelValueEmail' + room + '" value="' + contactChannel[i].contactChannelValue + '" placeholder="Email@email.com"/>' +
                '        </div>'+
                '        </div>';
        }
        html += 
            '<div class="col-sm-1"> <div class="form-group"> <button class="btn rounded-pill px-4 btn-light-danger text-danger font-weight-medium waves-effect waves-light" type="button" onclick="remove_education_fields(' + room + ');"> <i class="ri-delete-bin-line fs-5"></i> </button> </div></div>'
            + '</div>';
        divtest.innerHTML = html;

        objTo.appendChild(divtest);
        feather.replace();
        ///empty the fields
        $("#ddlChannel").val("");
        $("#ChannelValue").val("");
        $("#ddlChannel" + room).change(function (e) {
            var rowCount = e.currentTarget.dataset.count;
            var rowValue = e.currentTarget.value;
            var selectedType = e.currentTarget.options[e.currentTarget.options.selectedIndex].getAttribute('data-type');
            $('.phoneElement' + rowCount + ' input').val('');
            $('.emailElement' + rowCount + ' input').val('');
            if (selectedType == "Phone") {
                $(".phoneElement" + rowCount).show();
                $(".emailElement" + rowCount).hide();
                //remove required fields 
                $("#txtChannelValuePhone" + rowCount).attr("required", true);
                $("#txtChannelValuePhone" + rowCount).addClass("required")
                //$("#CountryCode" + rowCount).attr("required", true);
                //$("#CountryCode" + rowCount).addClass("required")
                //$("#AreaCode" + rowCount).attr("required", true);
                //$("#AreaCode" + rowCount).addClass("required")
                $("#Extension" + rowCount).attr("required", true);
                $("#Extension" + rowCount).addClass("required")
                //add required fields
                $("#txtChannelValueEmail" + rowCount).removeAttr("required");
                $("#txtChannelValueEmail" + rowCount).removeClass("required")

            } else if (selectedType == "Email") {
                $(".phoneElement" + rowCount).hide();
                $(".emailElement" + rowCount).show();
                //remove required fields 
                $("#txtChannelValuePhone" + rowCount).removeAttr("required");
                $("#txtChannelValuePhone" + rowCount).removeClass("required")
                //$("#CountryCode" + rowCount).removeAttr("required");
                //$("#CountryCode" + rowCount).removeClass("required")
                //$("#AreaCode" + rowCount).removeAttr("required");
                //$("#AreaCode" + rowCount).removeClass("required")
                $("#Extension" + rowCount).removeAttr("required");
                $("#Extension" + rowCount).removeClass("required")
                //add required fields
                $("#txtChannelValueEmail" + rowCount).attr("required", true);
                $("#txtChannelValueEmail" + rowCount).addClass("required");
            }
        });
        room++;
    }
    //disable fields
    $('#step1from :input').prop('disabled', true);
});
function Submit() {
    var obj = {};
    var objcontact = {};
    objcontact.recId = $("#RecId").val();
    objcontact.firstName = $("#FirstName").val();
    objcontact.lastName = $("#LastName").val();
    objcontact.middleName = $("#MiddleName").val();
    objcontact.registrationNo = $("#RegistrationNo").val();
    objcontact.genderCode = $("#GenderId").val();
    //objcontact.dob = $("#Dob").val();
    objcontact.yob = $("#YOB").val();
    objcontact.regionCode = $("#RegionCode").val();
    objcontact.job = $("#Job").val();
    objcontact.company = $("#Company").val();
    objcontact.contactChannel = getChannels();
    obj.contact = objcontact;
    var formBody = new FormData();
    formBody.append("contact", JSON.stringify(obj));
    $.ajax({
        url: "/Contact/edit",
        type: "POST",
        contentType: false,
        processData: false,
        data: formBody,
        success: function (data) {
            if (data.webResponseCommon.returnCode == '200') {
                toastr.success("", "Saved");
                //window.location.href = window.location.href;
            } else {
                toastr.warning("Please fix required fields", "UnSaved");
            }
            
        },
        error: function (xhr, status, error) {
            console.log("Error: " + error);
        }
    });
}

$("#btnTransaction").click(function () {
    var params = encodeParameters("?contactId=" + $("#RecId").val());
    window.location.href = "/transaction/Dashboard/"+params;
});
$("#btnEdit").click(function () {
    //enable fields
    $('#step1from :input').prop('disabled', false);
});