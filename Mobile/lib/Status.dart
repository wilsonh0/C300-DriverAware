import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';
import 'dart:async';
import 'package:flutter/src/widgets/table.dart';
//No Of Times Slept

class Status extends StatefulWidget {
  @override
  Status1 createState() => Status1();
}

class Status1 extends State<Status> {
  var date_lst = new List();
  var hours_lst = new List();
  var detect_lst = new List();
  var data;
  var all_data;
  bool isLoading = false;
  int length;
  //String url = 'https://c200-teamb-api.azurewebsites.net/api/Detections';
  String url = 'https://driverawareapi.azurewebsites.net/api/RecordedIncidents';

  Future<String> doRequest() async {
    var response = await http
        .get(Uri.encodeFull(url), headers: {"Accept": "application/json"});

    setState(() {
      var extractdata = json
          .decode(response.body); //the data is extracted from the json fromat
      isLoading = true;
      all_data = extractdata;
      length = all_data.length;
      //print(all_data);
      //adding the incident time and incident type from database to two lists.
      for (int i = 0; i < 5; i++) {
        data = all_data[i];
        date_lst.add(all_data[i]['incidentTime']);
        detect_lst.add(all_data[i]['incidentType']);
      }
      
    });
  }

  @override
  void initState() {
    this.doRequest();
  }

  // List data;

  Widget build(BuildContext context) {
    int length = date_lst.length;   
      
    return Scaffold(
      appBar: AppBar(
        title: Text("STATUS"),
      ),
      body: Container(
        decoration: BoxDecoration(
          image: DecorationImage(
            image: AssetImage('images/login.jpg'),
            fit: BoxFit.cover,
          ),
        ),
        child: Center(
          child: Column(
            children: [
              Image.network(
                'https://media.giphy.com/media/JhTeOkGxGlyFO/giphy.gif',
              ),
              Padding(
                padding: const EdgeInsets.only(top: 50.0),
                child: Table(
                  defaultColumnWidth: FixedColumnWidth(193.0),
                  border: TableBorder.all(
                      color: Colors.yellow[100],
                      style: BorderStyle.solid,
                      width: 5),
                  children: [
                    TableRow(children: [
                      Padding(
                        padding: const EdgeInsets.all(15),
                        child: Column(children: [
                          Text('DATE & TIME',
                              style: TextStyle(
                                  fontWeight: FontWeight.bold,
                                  fontSize: 20,
                                  color: Colors.amber[200]))
                        ]),
                      ),
                      Padding(
                        padding: const EdgeInsets.all(15.0),
                        child: Column(children: [
                          Text('STATUS',
                              style: TextStyle(
                                  fontWeight: FontWeight.bold,
                                  fontSize: 20.0,
                                  color: Colors.amber[200]))
                        ]),
                      ),                      
                    ]),
                    (TableRow(children: [
                      Padding(
                        padding: const EdgeInsets.all(15.0),
                        child: Column(children: [
                          Text(date_lst[length-1],
                              style: TextStyle(
                                  fontSize: 18.0,
                                  fontWeight: FontWeight.bold,
                                  color: Colors.white))
                        ]),
                      ),
                      Padding(
                        padding: const EdgeInsets.all(15.0),
                        child: Column(children: [
                          Text(detect_lst[length-1],
                              style: TextStyle(
                                  fontSize: 18.0,
                                  fontWeight: FontWeight.bold,
                                  color: Colors.white))
                        ]),
                      ),
                    ])),
                    (TableRow(children: [
                      Padding(
                        padding: const EdgeInsets.all(15.0),
                        child: Column(children: [
                          Text(date_lst[length - 2],
                              style: TextStyle(
                                  fontSize: 18.0,
                                  fontWeight: FontWeight.bold,
                                  color: Colors.white))
                        ]),
                      ),
                      Padding(
                        padding: const EdgeInsets.all(15.0),
                        child: Column(children: [
                          Text(detect_lst[length - 2],
                              style: TextStyle(
                                  fontSize: 18.0,
                                  fontWeight: FontWeight.bold,
                                  color: Colors.white))
                        ]),
                      ),
                    ])),
                    (TableRow(children: [
                      Padding(
                        padding: const EdgeInsets.all(15.0),
                        child: Column(children: [Text(date_lst[length - 3],
                        style: TextStyle(
                                  fontSize: 18.0,
                                  fontWeight: FontWeight.bold,
                                  color: Colors.white))]
                        ),
                      ),
                      Padding(
                        padding: const EdgeInsets.all(15.0),
                        child: Column(children: [Text(detect_lst[length - 3],
                        style: TextStyle(
                                  fontSize: 18.0,
                                  fontWeight: FontWeight.bold,
                                  color: Colors.white))]),
                      ),
                    ])),
                    (TableRow(children: [
                      Padding(
                        padding: const EdgeInsets.all(15.0),
                        child: Column(children: [Text(date_lst[length - 4],
                        style: TextStyle(
                                  fontSize: 18.0,
                                  fontWeight: FontWeight.bold,
                                  color: Colors.white))]),
                      ),
                      Padding(
                        padding: const EdgeInsets.all(15.0),
                        child: Column(children: [Text(detect_lst[length - 4],
                        style: TextStyle(
                                  fontSize: 18.0,
                                  fontWeight: FontWeight.bold,
                                  color: Colors.white))]),
                      ),
                    ])),
                    (TableRow(children: [
                      Padding(
                        padding: const EdgeInsets.all(15.0),
                        child: Column(children: [Text(date_lst[length - 5],
                        style: TextStyle(
                                  fontSize: 18.0,
                                  fontWeight: FontWeight.bold,
                                  color: Colors.white))]),
                      ),
                      Padding(
                        padding: const EdgeInsets.all(15.0),
                        child: Column(children: [Text(detect_lst[length - 5],
                        style: TextStyle(
                                  fontSize: 18.0,
                                  fontWeight: FontWeight.bold,
                                  color: Colors.white))]),
                      ),
                    ])),
                  ],
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
