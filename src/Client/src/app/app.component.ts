import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { WeatherService } from './services/weather.service';
import { CityWeather } from './services/weather.service';



@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  formGroup!: FormGroup;
  cities: any[] = [];
  weather: CityWeather | null = null;
  history: any[] = [];
  loading: boolean = false;

  constructor(private fb: FormBuilder, private weatherService: WeatherService) { }

  ngOnInit(): void {
    this.formGroup = this.fb.group({
      selectedCity: [null],
      showHistory: [false]
    });

    this.cities = [
      { name: 'London', code: 'LDN' },
      { name: 'New York', code: 'NY' },
      { name: 'Tokyo', code: 'TKY' }
      // Agrega más ciudades según sea necesario
    ];
  }

  load(): void {
    const city = this.formGroup.get('selectedCity')?.value;
    const showHistory = this.formGroup.get('showHistory')?.value;

    if (city) {
      this.loading = true;
      this.weatherService.getWeather(city.name).subscribe((data) => {
        this.weather = data;
        this.loading = false;
      }, error => {
        console.log(error);
        this.loading = false;
      });

      if (showHistory) {
        this.weatherService.getHistory().subscribe((data) => {
          this.history = data;
        }, error => {
          console.log(error);
        });
      } else {
        this.history = [];
      }
    }
  }
}