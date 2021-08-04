import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';
import 'dart:async';
import 'package:flutter/src/widgets/table.dart';
//No Of Times Slept

class TimesSlept extends StatefulWidget {
  @override
  TimesSlept1 createState() => TimesSlept1();
}

class TimesSlept1 extends State<TimesSlept> {
  var date_lst = new List();
  var hours_lst = new List();
  var data;
  var all_data;
  bool isLoading = false;
  int length;
  String url = 'https://c200-teamb-api.azurewebsites.net/api/TimeSlept';

  Future<String> doRequest() async {
    var response = await http
        .get(Uri.encodeFull(url), headers: {"Accept": "application/json"});

    setState(() {
      var extractdata = json
          .decode(response.body); //the data is extracted from the json fromat
      isLoading = true;
      all_data = extractdata;
      length = all_data.length;
      print(all_data);
      //adding the username and passwords from database to two lists.
     /* for (int i = 0; i < 3; i++) {
        data = all_data[i];
        date_lst.add(data['sensorId']);
        hours_lst.add(data['deviceId']);
      }*/
      print("date_lst");
      hours_lst=['2'];
      date_lst=['12-1-2021'];
    });
  }

  @override
  void initState() {
    this.doRequest();
  }

  // List data;

  Widget build(BuildContext context) {
    hours_lst=['7.5','8.2','7.3','5.4','9.0'];
      date_lst=['17-1-2021','16-1-2021','14-1-2021','12-1-2021','11-1-2021'];
      int length = date_lst.length;
    return Scaffold(
      appBar: AppBar(
        title: Text("Ride Hours"),
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
                'https://media4.giphy.com/media/3o6Zt20M3uA972k3gQ/giphy.gif?cid=ecf05e47ln76u7j3hm73oagwekjovl8fykol5snher87pfdy&rid=giphy.gif',
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
                          Text('DATE',
                              style: TextStyle(
                                  fontWeight: FontWeight.bold,
                                  fontSize: 20,
                                  color: Colors.amber[200]))
                        ]),
                      ),
                      Padding(
                        padding: const EdgeInsets.all(15.0),
                        child: Column(children: [
                          Text('RIDE HOURS',
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
                          Text(hours_lst[length-1],
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
                          Text(hours_lst[length - 2],
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
                                  color: Colors.white))]),
                      ),
                      Padding(
                        padding: const EdgeInsets.all(15.0),
                        child: Column(children: [Text(hours_lst[length - 3],
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
                        child: Column(children: [Text(hours_lst[length - 4],
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
                        child: Column(children: [Text(hours_lst[length - 5],
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
