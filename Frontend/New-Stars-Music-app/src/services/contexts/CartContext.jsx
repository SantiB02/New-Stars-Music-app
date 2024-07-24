import { createContext, useReducer, useState } from "react";

export const CartContext = createContext();

export function CartProvider({ children }) {
  const [cartTotal, setCartTotal] = useState(
    localStorage.getItem("cartTotal")
      ? Number(localStorage.getItem("cartTotal"))
      : 0
  );
  const initialState = JSON.parse(window.localStorage.getItem("cart")) || [];

  // update local storage when cart changes
  const updateLocalStorage = (state) => {
    window.localStorage.setItem("cart", JSON.stringify(state));
  };

  const reducer = (state, action) => {
    const { type: actionType, payload: actionPayload } = action;

    switch (actionType) {
      case "ADD_TO_CART":
        const newState = [...state, actionPayload];
        updateLocalStorage(newState);
        const productPrice = Number(actionPayload.price);
        const productQuantity = Number(actionPayload.quantity);
        const newTotal = cartTotal + productPrice * productQuantity;
        setCartTotal(newTotal);
        localStorage.setItem("cartTotal", newTotal);
        return newState;

      case "REMOVE_FROM_CART": {
        const productToRemove = state.find(
          (item) => item.id === actionPayload.id
        );
        if (!productToRemove) return state; // Si el producto no se encuentra, no hacer nada
        const newState = state.filter((item) => item.id !== actionPayload.id);
        updateLocalStorage(newState);
        const newTotal =
          cartTotal - productToRemove.price * productToRemove.quantity;
        setCartTotal(newTotal);
        localStorage.setItem("cartTotal", newTotal);
        return newState;
      }
      case "CLEAR_CART": {
        const initialState = [];
        localStorage.removeItem("cart");
        localStorage.removeItem("cartTotal");
        return initialState;
      }
      default:
    }
  };
  const [state, dispatch] = useReducer(reducer, initialState);

  const addToCart = (product) => {
    dispatch({ type: "ADD_TO_CART", payload: product });
  };

  const removeFromCart = (product) => {
    dispatch({ type: "REMOVE_FROM_CART", payload: product });
  };

  const clearCart = () => {
    dispatch({ type: "CLEAR_CART" });
  };

  return (
    <CartContext.Provider
      value={{
        cart: state,
        cartTotal,
        addToCart,
        clearCart,
        removeFromCart,
      }}
    >
      {children}
    </CartContext.Provider>
  );
}
