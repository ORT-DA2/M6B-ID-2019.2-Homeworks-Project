import { Component, OnInit } from '@angular/core';

const ELEMENT_DATA: string[] = [
  "Rojo", "Verde", "Amarillo", "Azul"
];

@Component({
  selector: 'ejemplo',
  templateUrl: './comp-ejemplo.component.html',
  styleUrls: ['./comp-ejemplo.component.css']
})
export class CompEjemploComponent implements OnInit {
    title: string = "Colors: ";
    colors: string[] = ELEMENT_DATA;
    show: boolean = false;
  constructor() { }

  ngOnInit() {
  }

}
