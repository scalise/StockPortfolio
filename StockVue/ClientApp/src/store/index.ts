import Vue from 'vue';
import Vuex, { StoreOptions } from 'vuex';
import { actions } from './actions';
import { getters } from './getters';
import { mutations } from './mutations';
import { RootState } from './types';
import { counter } from './counter/index';
import { positions } from './positions/index';

Vue.use(Vuex);

// Vuex structure based on https://codeburst.io/vuex-and-typescript-3427ba78cfa8

const store: StoreOptions<RootState> = {
    state: {
        urlBase: 'localhost:7071', // where to get the data
        version: '1.0.0', // a simple property        
        summary: { balance: NaN, totalCash: 0, totalPositions: 0, todaysNetChangePercent: 0, todaysNetChangeValue: 0 },
        history: { data:[], labels:[]}
    },
    actions,
    getters,
    mutations,
    modules: {
        counter,
        positions,
    },
};

export default new Vuex.Store<RootState>(store);
