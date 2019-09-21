import { NgModule } from '@angular/core';
import { HotelModule } from '../hotel.module';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from "@angular/forms";
import { HotelSearcherComponent } from './hotel.searcher.component';

@NgModule({
    imports: [HotelModule, BrowserModule, FormsModule],
    declarations: [HotelSearcherComponent],
    exports: [HotelSearcherComponent]
})
export class HotelSearcherModule { }