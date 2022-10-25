import { createStore, applyMiddleware, compose } from 'redux';
import rootReducer from '../rootReducer';
import thunk from 'redux-thunk';

export const configureStore = () => {
  const store = createStore(
    rootReducer,
    compose(applyMiddleware(thunk), compose)
  );
  return store;
};
// const store = createStore(()=>[], {}, applyMiddleware());