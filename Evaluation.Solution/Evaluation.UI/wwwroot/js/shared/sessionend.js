//const sessionHubConnection = new signalR.HubConnectionBuilder()
//    .withUrl("/sessionHub")
//    .build();

//sessionHubConnection.start().then(function () {
//    console.log("SignalR connected");
//}).catch(function (err) {
//    return console.error(err.toString());
//});

let sessionTimeoutWarningDuration = 180 * 60 * 1000; // 5 minutes warning before session ends
let sessionTimeoutDuration = 90 * 60 * 1000; // 20 minutes session timeout

//setTimeout(function () {
   // alert("Your session will expire soon. Please save your work.");

   
    setTimeout(function () {
        Swal.fire(
            {
                title: "Session Expired",
                text: "Your session has expired. Please log in again.",
                type: "warning",
                //showCancelButton: true,
                confirmButtonColor: "green",
                confirmButtonText: "Login",
                closeOnConfirm: false,
            }).then((result) => {
                if (result.value) {
                    window.location.href = "/Login/Index"; // Redirect to login page
                }
            });
       // alert("");
     
    }, sessionTimeoutWarningDuration);
//}, sessionTimeoutDuration - sessionTimeoutWarningDuration);