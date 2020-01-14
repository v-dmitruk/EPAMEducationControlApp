import { Teacher } from './teacher.model';
import { Course } from './course.model';

export class Lection {
    LectionID : number;
    LectionType : string;
    Name : string;
    Description : string;
    LectionBody : string;
    MaxMark : number;
    AdditionalMarkIsAvailable : boolean;
    Creator : Teacher;
    CreationDate : Date;
    Courses : Course;
    Date : Date;
}
