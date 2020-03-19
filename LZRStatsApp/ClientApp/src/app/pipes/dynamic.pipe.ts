import {
    Injector,
    Pipe,
    PipeTransform,
    Type
} from '@angular/core';


@Pipe({
    name: 'dynamicPipe'
})
export class DynamicPipe implements PipeTransform {

    public constructor(private injector: Injector) {
    }

    transform(value: any, pipeToken: Pipe, pipeArgs: any[]): any {
        if (!pipeToken) {
            return value;
        }

        const pipe = this.injector.get<PipeTransform>(pipeToken as Type<PipeTransform>);
        return pipe.transform(value, ...pipeArgs);
    }
}
