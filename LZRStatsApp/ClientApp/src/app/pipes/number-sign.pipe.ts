import { Pipe, PipeTransform } from '@angular/core';

@Pipe({name: 'numberSignPipe'})
export class NumberSignPipe implements PipeTransform {
  transform(value: number): string {
    return `#${value}`;
  }
}