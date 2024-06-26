﻿namespace Basket.API.Data;

public class BasketRepository (IDocumentSession session)
    : IBasketRepository
{
    public async Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellation = default)
    {
        ShoppingCart basket = await session.LoadAsync<ShoppingCart>(userName, cancellation) ?? throw new BasketNotFoundException(userName);

        return basket;
    }

    public async Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellation = default)
    {
        session.Store(basket);
        await session.SaveChangesAsync(cancellation);

        return basket;
    }

    public async Task<bool> DeleteBasket(string userName, CancellationToken cancellation = default)
    {
        session.Delete<ShoppingCart>(userName);
        await session.SaveChangesAsync(cancellation);

        return true;
    }
}
