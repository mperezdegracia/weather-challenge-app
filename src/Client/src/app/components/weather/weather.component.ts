import { Component, OnInit } from '@angular/core';
import { WeatherService } from '../../services/weather.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [],
  templateUrl: './weather.component.html',
  styleUrl: './weather.component.css'
})
export class WeatherComponent implements OnInit {

  city: string = '';
  weather: any;

  constructor(private weatherService: WeatherService) { }

  ngOnInit(): void {
  }

  getWeather(): void {

    this.weatherService.getWeather(this.city).subscribe((data) => {
      console.log(data);
      this.weather = data;
    },
      error => {
        console.log(error);
      }
    );
  }

  getHistory(): void {

    this.weatherService.getHistory().subscribe((data) => {
      console.log(data);
    },
      error => {
        console.log(error);
      }
    );
  }



}
