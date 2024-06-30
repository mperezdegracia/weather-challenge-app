import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

/*
  Data model to be fetched from API
*/
export interface CityWeather {
  city: string;
  country: string;
  temperature: number;
  feelsLike: number;
}

@Injectable({
  providedIn: 'root'
})
export class WeatherService {

  private apiUrl = "http://localhost:5129/api/weather"

  constructor(private http: HttpClient) { }

  getWeather(city:string): Observable<CityWeather> {
    return this.http.get<CityWeather>(`${this.apiUrl}/${city}`);
  }

  getHistory(): Observable<CityWeather[]> {
    return this.http.get<CityWeather[]>(`${this.apiUrl}/history`);  
  }


}
