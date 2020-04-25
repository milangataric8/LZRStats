import { Pipe, PipeTransform } from '@angular/core';

@Pipe({name: 'percentSignPipe'})
export class PercentSignPipe implements PipeTransform {
  transform(value: number): string {
    return `${value}%`;
  }
}