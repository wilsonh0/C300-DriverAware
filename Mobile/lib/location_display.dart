//import 'dart:html';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:login_app/model/location_model.dart';
import 'package:provider/provider.dart';

class Location_display extends StatelessWidget {
  @override
  Widget build(BuildContext context){
    var locationModel = Provider.of<LocationModel>(context);

    return Scaffold(
      appBar: AppBar(),
      body: Container(
        child: Text('Lattitude: ${locationModel.latitude} , Longitude : ${locationModel.longitude}'),
      )
    );
  }
}