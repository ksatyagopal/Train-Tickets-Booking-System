// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function sleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
}

async function closetoast(time = 0) {
    var toast = document.getElementById("mytoast");
    for (let i = 0; i < time; i++) {
        await sleep(1000);
    }
    toast.style.display = "none";
    toast.style.opacity = 0;
    toast.style.zIndex = -10;
}

async function closeProfileToast() {
    var toast = document.getElementById("profileToast");
    toast.style.opacity = 0;
    toast.style.zIndex = -10;
}

async function showProfile() {
    var toast = document.getElementById("profileToast");
    toast.style.opacity = 1;
    toast.style.zIndex = 10;
}

//$(document).ready(function () {
    
//    var next = 0;
//    $("#add-more").click(function (e) {
//        e.preventDefault();
//        var addto = "#field" + next;
//        var addRemove = "#field" + (next);
//        next = next + 1;
//        var newIn = ' <div id="field' + next + '" name="field' + next + '"><!-- Text input--><div class="form-group"> <label class="col-md-4 control-label" for="action_id">Passenger Name</label> <div class="col-md-5"> <input asp-for="@Model["' + next + '"].PassengerName" id="action_id" name="action_id" type="text" placeholder="" class="form-control input-md"> </div></div><br><br> <!-- Text input--><div class="form-group"> <label class="col-md-4 control-label" for="action_name">Age</label> <div class="col-md-5"> <input asp-for="@Model["' + next + '"].Age" id="action_name" name="action_name" type="text" placeholder="" class="form-control input-md"> </div></div><br><br><div class="form-group"><label class="col-md-4 control-label" for="action_name">Gender</label>  <div class="col-md-5"><select asp-for="@Model["' + next +'"].PassengerName" id="action_gen" name="action_gen" type="text" placeholder="" class="form-control input-md"><option value="M">Male</option><option value="F">Female</option><option value="O">Others</option></select></div></div><br><br>';
//        var newInput = $(newIn);
//        var removeBtn = '<button id="remove' + (next - 1) + '" class="btn btn-danger remove-me" >Remove</button></div></div><div id="field">';
//        var removeButton = $(removeBtn);
//        $(addto).after(newInput);
//        $(addRemove).after(removeButton);
//        $("#field" + next).attr('data-source', $(addto).attr('data-source'));
//        $("#count").val(next);

//        $('.remove-me').click(function (e) {
//            e.preventDefault();
//            var fieldNum = this.id.charAt(this.id.length - 1);
//            var fieldID = "#field" + fieldNum;
//            $(this).remove();
//            $(fieldID).remove();
//        });
//    });

//});