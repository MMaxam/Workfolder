function Login(){
    var uName = "Kakashi";
    var pWord = "0791346591";
    var username = document.getElementById("Username").value;
    var Password = document.getElementById("Password").value;

    if (username == uName && Password == pWord) {
        location.replace("Home.html");
        console.log("Shit works")
        return true;
    } else {
        return false;
    }

}

function myMap() {
    var mapProp= {
      center:new google.maps.LatLng(51.508742,-0.120850),
      zoom:5,
    };
    var map = new google.maps.Map(document.getElementById("googleMap"),mapProp);
    }