import { ActionTree } from 'vuex';
import { PositionsState, Position } from './types';
import { RootState } from '../types';
import axios from 'axios';

export const actions: ActionTree<PositionsState, RootState> = {
    addPosition({ commit }, position: Position): any {
        const positionUrl = 'http://' + this.state.urlBase + '/api/portfolio/XXXXXXXXX/position';

        return new Promise((resolve, reject) => {                    
            axios.post(positionUrl, {
                ticker: position.ticker,
                name: position.name,
                numShares: position.numberOfShares,
                purchasePrice: position.avgPrice
            })
                .then((resp) => {
                console.log('updating data from API call');
                //fill in details from API
                position.currentPrice = resp.data.currentPrice;
                position.marketValue = resp.data.marketValue;
                position.gainPct = resp.data.gainPercentage;
                position.gainValue = resp.data.gainValue;

                commit('addPosition', position);
                resolve(position);            
            })
            .catch(error => {
                reject(error);
            });
        });        
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
