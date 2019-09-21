import { NgModule } from '@angular/core';
import { HotelRepository } from './hotel.repository';
import { HotelStaticDataSource } from './hotel.static.datasource';

@NgModule({
    providers: [HotelRepository, HotelStaticDataSource]
})
export class HotelModule { }