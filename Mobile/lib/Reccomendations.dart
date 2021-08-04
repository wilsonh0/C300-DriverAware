import 'package:flutter/material.dart';

class Recom {
  final String info;
  final String imageURL;

  Recom({this.info, this.imageURL});
}

//Recomendations
class Reccomendations extends StatelessWidget {
  int x =2;
  final recom = [    
    Recom(
        info: "Listen to favorite music to keep you alert.",
        imageURL: "music.jpg"),
    Recom(info: "Do not ride more than 8 hours.", imageURL: "cycle.jpg"),
    Recom(info: "Do not drink and drive.", imageURL: "alcohol.jpg"),
    Recom(
        info: "Always break for 15 minutes after 2 hour ride.",
        imageURL: "plane.jpg"),
    Recom(info: "Have coffee to keep you awake.", imageURL: "coffee.jpg")
  ];
    
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text("Reccomendations"),
      ),
      body: Container(
        decoration: BoxDecoration(
          image: DecorationImage(
            image: AssetImage('images/login.jpg'),
            fit: BoxFit.cover,
          ),
        ),       
        child: ListView.builder(
            itemCount: recom.length,
            itemBuilder: (context, index) {
              final recoms = recom[index];
              return Padding(
                padding: const EdgeInsets.all(20.0),
                child: RaisedButton(
                  shape: StadiumBorder(),
                  child: ListTile(
                    shape: Border(),
                    title: Text(
                      recoms.info,
                      style: TextStyle(
                          fontWeight: FontWeight.bold, color: Colors.white),
                    ),
                    leading: new CircleAvatar(
                      backgroundImage: AssetImage('images/' + recoms.imageURL),
                    ),
                  ),
                  color: Colors.purple[400],
                  onPressed: () {},
                ),
              );
            }),                        
      ),      
    );         
    
                      
  }
  
}
