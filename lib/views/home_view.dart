import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:get/get.dart';
import 'package:nezet_frissites/controllers/home_view_controller.dart';

class HomeView extends StatelessWidget {
  HomeViewController controller = Get.put(HomeViewController());

  @override
  Widget build(BuildContext context) {
    return GetBuilder<HomeViewController>(
      init: controller,
      builder: (_) {
        return Scaffold(
          body: Center(
            child: Column(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                Row(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: controller.getIcons(),
                ),
                CupertinoButton.filled(
                  child: Icon(Icons.plus_one),
                  onPressed: () {
                    controller.noveld();
                  },
                ),
                SizedBox(
                  height: 10,
                ),
                CupertinoButton.filled(
                  child: Icon(Icons.exposure_minus_1_sharp),
                  onPressed: () {
                    controller.csokkent();
                  },
                ),
              ],
            ),
          ),
        );
      },
    );
  }
}
