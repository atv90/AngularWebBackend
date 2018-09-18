import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
    title = 'Ensimmäinen Angular-sovellus';
    //määritellää orderCount-ominaisuus, jolle asetetaan lähtöarvo
    orderCount = -1;
}
