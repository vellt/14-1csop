import 'package:flutter/material.dart';
import 'package:get/get.dart';

class HomeViewController extends GetxController {
  // privát változó, csak az osztályon belül
  // érhető el
  int szamlalo = 0;

  // nézet fogja meghívni
  void noveld() {
    if (szamlalo < 5) {
      szamlalo++;
      update();
    }
  }

  // nézet fogja meghívni
  void csokkent() {
    if (szamlalo > 0) {
      szamlalo--;
      update();
    }
  }

  // nézet ezt fogja betölteni, mint akt. adat
  List<Icon> getIcons() {
    List<Icon> temp = [];
    for (int i = 0; i < 5; i++) {
      temp.add(Icon((i < szamlalo) ? Icons.star : Icons.star_border));
    }
    return temp;
  }
}
