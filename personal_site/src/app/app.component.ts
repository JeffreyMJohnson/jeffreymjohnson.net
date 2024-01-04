import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MenuComponent } from './menu/menu.component';



interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  

  constructor(private http: HttpClient) {}

  ngOnInit() {
    
  }

  title = 'personal_site';
}
