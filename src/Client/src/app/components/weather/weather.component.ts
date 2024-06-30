import { Component, OnInit } from '@angular/core';
import { CityWeather, WeatherService } from '../../services/weather/weather.service';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { CityService } from '../../services/city/city.service';
import { Router } from '@angular/router';
import { DropdownModule } from 'primeng/dropdown';
import { CheckboxModule } from 'primeng/checkbox';
import { ButtonModule } from 'primeng/button';
import { TableModule } from 'primeng/table';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-weather',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    DropdownModule,
    CheckboxModule,
    ButtonModule,
    TableModule
  ],
  templateUrl: './weather.component.html',
  styleUrl: './weather.component.css'
})
export class WeatherComponent  implements OnInit {
  formGroup!: FormGroup;
  cities: any[] = [];
  weather: CityWeather | null = null;
  history: any[] = [];
  loading: boolean = false;

  constructor(private fb: FormBuilder, private weatherService: WeatherService, private cityService: CityService,private router: Router ) { }

  ngOnInit(): void {
    this.formGroup = this.fb.group({
      selectedCity: [null],
      showHistory: [false]
    });

    this.loadCities();
  }

  goToCities(): void {
    this.router.navigate(['/cities']);
  }
  
  loadCities(): void {
    this.cityService.getAll().subscribe(
      cities => {
        this.cities = cities;
      },
      error => {
        console.error('Error loading cities:', error);
      }
    );
  }
  addCity(city: string, country: string): void {
    this.cityService.add(city, country).subscribe(
      () => {
        this.loadCities(); // Refresh cities list after addition
      },
      error => {
        console.error('Error adding city:', error);
      }
    );
  }

  removeCity(id: number): void {
    this.cityService.remove(id).subscribe(
      () => {
        this.loadCities(); // Refresh cities list after removal
      },
      error => {
        console.error('Error removing city:', error);
      }
    );
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