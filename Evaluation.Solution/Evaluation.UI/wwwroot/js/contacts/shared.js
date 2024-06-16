var room = 1;

function addChannel() {
    room++;
    var objTo = document.getElementById("ChannelListView");
    var divtest = document.createElement("div");
    divtest.setAttribute("class", "mb-3 removeclass" + room);

    var selectChannelHtml = "<select id='ddlChannel" + room + "' required name='ddlChannel" + room + "' data-count='" + room + "' class='selectChannel select2 form-select required' >";
    selectChannelHtml += "<option value=''>--Select--</option>";
    for (var i = 0; channelsList.length > i; i++) {
        //if (channel == channelsList[i].code) {
        //    selectChannelHtml += "<option value='" + channelsList[i].code + "' selected data-type='" + channelsList[i].type + "'>" + channelsList[i].description + "</option>";
        //} else {
        selectChannelHtml += "<option value='" + channelsList[i].code + "' data-type='" + channelsList[i].type + "'>" + channelsList[i].description + "</option>";
        //}

    }
    selectChannelHtml += "</select>";


    var html = '<div class="row" data-count="' + room + '">' +
        '    <div class="col-sm-3">' +
        '        <div class="mb-3">' +
        selectChannelHtml +
        '        </div>' +
        '    </div>' +
        //'    <div class="col-sm-2 phoneElement' + room + ' hide">' +
        //'        <div class="mb-3">' +
        //'<input type="number" class="form-control required" id="CountryCode' + room + '" name="CountryCode' + room + '" placeholder="Country Code">' +
        //'        </div>' +
        //'    </div>' +
        //'    <div class="col-sm-2 phoneElement' + room + ' hide">' +
        //'        <div class="mb-3">' +
        //'<input type="number" class="form-control required" id="AreaCode' + room + '" name="AreaCode' + room + '" placeholder="Area Code">' +
        //'        </div>' +
        //'    </div>' +
     
     
        '    <div class="col-sm-2 phoneElement' + room + ' hide" >' +
        '        <div class="mb-3">' +
        '            <input type="number" class="form-control required" onblur="onloseFocuce(this)"  required id="txtChannelValuePhone' + room + '" name="txtChannelValuePhone' + room + '" value="" placeholder="Ex: +961 71776614"/>' +
        '        </div>' +
        '    </div>' +
        '    <div class="col-sm-4 emailElement' + room + '" >' +
        '        <div class="mb-3">' +
        '            <input type="email" class="form-control required" required id="txtChannelValueEmail' + room + '" name="txtChannelValueEmail' + room + '" value="" placeholder="Email@email.com"/>' +
        '        </div>' +
        '    </div>' +
        '    <div class="col-sm-2 phoneElement' + room + ' hide">' +
        '        <div class="mb-3">' +
        '<input type="number" class="form-control" id="Extension' + room + '" name="Extension' + room + '" placeholder="Extension">' +
        '        </div>' +
        '    </div>' +
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
            //$("#Extension" + rowCount).attr("required", true);
            //$("#Extension" + rowCount).addClass("required")
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
            //$("#Extension" + rowCount).removeAttr("required");
            //$("#Extension" + rowCount).removeClass("required")
            //add required fields
            $("#txtChannelValueEmail" + rowCount).attr("required", true);
            $("#txtChannelValueEmail" + rowCount).addClass("required")
        }
        console.log(1);
    });

}
function onloseFocuce(e) {
    searchContactByNumber(e.value);
}
function remove_education_fields(rid) {
    $(".removeclass" + rid).remove();
}

function getChannels() {
    var channelList = [];
    $("#ChannelListView div> .row").each(function (index) {
        var currentRowChannelValue = "";
        var currentItem = $(this);
        var currentRownNumber = currentItem.data("count");
        var currentRowId = $("#RecId" + currentRownNumber).val();
        if (currentRowId == null || currentRowId == "") {
            currentRowId = -1;
        }
        var currentRowChannel = $("#ddlChannel" + currentRownNumber).val();
        var currentRowChannelValueEmail = $("#txtChannelValueEmail" + currentRownNumber).val();
        var currentRowChannelValuePhone = $("#txtChannelValuePhone" + currentRownNumber).val();
        //var countryCode = $("#CountryCode" + currentRownNumber).val();
        //var areaCode = $("#AreaCode" + currentRownNumber).val();
        var extension = $("#Extension" + currentRownNumber).val();
        if (currentRowChannelValueEmail != "" && currentRowChannelValueEmail !=null) {
            currentRowChannelValue = currentRowChannelValueEmail;
           // countryCode = 0;
            //areaCode = 0;
            extension = 0;
        } else {
            currentRowChannelValue = currentRowChannelValuePhone;
        }
        var education = {
            "recId": currentRowId,
            "channelCode": currentRowChannel,
            "contactChannelValue": currentRowChannelValue,
            //"countryCode": countryCode,
            //"areaCode": areaCode,
            "extension": extension,
        };

        channelList.push(education);
    });
    return channelList;
}
