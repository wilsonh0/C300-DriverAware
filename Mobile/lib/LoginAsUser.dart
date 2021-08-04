import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:url_launcher/url_launcher.dart';
import 'package:location/location.dart';
//import 'package:fluttertoast/fluttertoast.dart';
//Home Page With four buttons
class LoginAsUser extends StatelessWidget {
  Location location = new Location();
int reward= 1000;
bool _isserviceEnabled;
PermissionStatus _permissionGranted;
LocationData _locationData;
bool _isListenLocation=false,_isGetLocation=false;


  Widget build(BuildContext context) {
    return Scaffold(      
      appBar: AppBar(        
        title: Text("Home"),      
        actions: <Widget>[               
        IconButton(icon: Icon(Icons.monetization_on_rounded,size: 35.0),color: Colors.yellowAccent,onPressed: () {launch('https://www.income.com.sg/health-and-personal-accident/pa-secure?gclid=Cj0KCQjw0emHBhC1ARIsAL1QGNf7w9niIM3g0DWZl77pH5jQAqvT9CAHM1G_LTovlQjqso2SFLDVK1gaAlDnEALw_wcB');}),
        Center(child: Text(reward.toString(),textAlign: TextAlign.center,style: TextStyle(fontSize: 20.0,color: Colors.purpleAccent))),
      ],
      
      ),
            
      body:       
      Container(        
        decoration: BoxDecoration(
          image: DecorationImage(
            image: AssetImage('images/login.jpg'),
            fit: BoxFit.cover,
          ),
        ),        
        child: Container(
          child: Align(
            alignment: Alignment(0, 0),
            child: Column(
              children: <Widget>[
                Image.network(
                    'https://media1.giphy.com/media/l4Ho7AfNzHCtwGR0s/giphy.gif?cid=ecf05e47zylftbi12z49ym9u0th3ctrxzuduznvy3fn51h3d&rid=giphy.gif'),
                Center(
                  child: Padding(
                    padding: const EdgeInsets.all(10.0),
                    child: Container(
                      margin: const EdgeInsets.only(top: 25.0),
                      child: RaisedButton(
                        shape: StadiumBorder(),
                        child: Text("Status"),
                        color: Colors.greenAccent,
                        onPressed: () {                          
                          Navigator.pushNamed(context, '/Status');
                        },
                      ),
                    ),
                  ),
                ),
                Padding(
                  padding: const EdgeInsets.all(20.0),
                  child: RaisedButton(
                    shape: StadiumBorder(),
                    child: Text("Maps"),
                    color: Colors.greenAccent,
                    onPressed: () 
                      async{
                    var ena = await location.serviceEnabled();
                    if(! ena) {
                      ena = await location.requestService();
                      if(!ena){
                        return;
                      }
                    }
                    var per = await location.hasPermission();
                    if (per == PermissionStatus.denied){
                      per = await location.requestPermission();
                     if(per != PermissionStatus.granted){
                       return;
                     }
                    }
                    _locationData = await location.getLocation();
                    print(_locationData);
                    //Fluttertoast.showToast(backgroundColor: Colors.yellow,fontSize: 20, msg: 'fkjd');
                      launch('https://www.google.com.sg/maps/');                     
                    },
                  ),
                ),
                Padding(
                  padding: const EdgeInsets.all(20.0),
                  child: RaisedButton(
                    shape: StadiumBorder(),
                    child: Text("Ride Hours"),
                    color: Colors.greenAccent,
                    onPressed: () {
                   Navigator.pushNamed(context, '/TimesSlept');
                    },
                  ),
                ),
                Padding(
                  padding: const EdgeInsets.all(20.0),
                  child: RaisedButton(
                    shape: StadiumBorder(),
                    child: Text("Reccomendations"),
                    color: Colors.greenAccent,
                    onPressed: () {                     
                      Navigator.pushNamed(context, '/Reccomendations');
                    },
                  ),
                ),
                 Padding(
                  padding: const EdgeInsets.all(20.0),
                  child: RaisedButton(
                    shape: StadiumBorder(),
                    child: Text("Location"),
                    color: Colors.greenAccent,
                    onPressed: () {                     
                      Navigator.pushNamed(context, '/location_display');
                    },
                  ),
                ),
              ],
            ),
          ),
        ),
      ),
    );    
  }
}
