import { ProductModel } from "./product.model";

export interface OrderModel {
    products: ProductModel[];
    shipment: Shipment;
    dateOfOrder: Date;
    price: number;

}
export enum Shipment{
    DHL, DPD
}