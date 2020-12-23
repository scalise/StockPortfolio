import { Module } from 'vuex';
import { getters } from './getters';
import { actions } from './actions';
import { mutations } from './mutations';
import { PositionsState } from './types';
import { RootState } from '../types';

export const state: PositionsState = {
  positions: [],
};

const namespaced: boolean = true;

export const positions: Module<PositionsState, RootState> = {
  namespaced,
  state,
  getters,
  actions,
  mutations,
};
