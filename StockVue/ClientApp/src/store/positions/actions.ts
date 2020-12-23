import { ActionTree } from 'vuex';
import { PositionsState, Position } from './types';
import { RootState } from '../types';
import axios from 'axios';

export const actions: ActionTree<PositionsState, RootState> = {
    addPosition({ commit }, position): any {
        commit('addPosition', position);
  },
    removePosition({ commit }, positionTicker: string): any {
        commit('removePosition', positionTicker);
    },
    loadStockPositions({ commit }) {        
        console.log('Entered loadStockPositions');
        const positionsUrl = 'http://' + this.state.urlBase + '/api/portfolio/XXXXXXXXX/positions';
        //axios.get(positionsUrl).then((resp) => {
        //    commit('loadStockPositions', resp.data);
        //}).catch(error => {
        //    throw new Error(`API ${error}`);
        //});        
        
        //TODO: Dummy data. replace this with the actual data
        commit('loadStockPositions', {});

    },
};
