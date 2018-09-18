import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
    title: string = 'Ensimmäinen Angular-sovellus';
    //määritellään orderCount-ominaisuus, jolle asetetaan lähtöarvo
    orderCount: number = -1;

    constructor(private http: HttpClient) {

    }
    ngOnInit(): void {
        //Make the HTTP request:
        this.http.get('/api/values/ordercount').subscribe(data => {
            //read the result field from the JSON response.
            this.orderCount = parseInt(data.toString());
        });
    }
}
