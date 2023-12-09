import { User } from "src/app/core/models/user"

export class ContentUpdateDto{
    id!:string
    title!: string
    text!: string
    categoryId!:string
    imageUrl!:string
    user!:User
}