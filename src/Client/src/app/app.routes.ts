import { Routes } from '@angular/router';
import { WeatherComponent } from './components/weather/weather.component';
import { CityComponent } from './components/city/city.component';

export const routes: Routes = [

    {path: 'weather', component: WeatherComponent},
    {path: 'cities', component: CityComponent},
    {path: '**', redirectTo: '/weather' }
];
