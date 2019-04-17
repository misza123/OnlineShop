import { Component, OnInit, Input } from '@angular/core';
import { Address } from '../address';

@Component({
  selector: 'app-address-edit',
  templateUrl: './address-edit.component.html',
  styleUrls: ['./address-edit.component.css']
})
export class AddressEditComponent implements OnInit {
  @Input() address: Address;
  constructor() { }

  ngOnInit() {
  }

}
