import { Pipe, PipeTransform } from '@angular/core';

@Pipe({name: 'numberSign'})
export class NumberSign implements PipeTransform {
  transform(value: number): string {
    return `#${value}`;
  }
}