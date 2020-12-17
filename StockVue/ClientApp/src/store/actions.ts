﻿import { ActionTree } from 'vuex';
import { RootState } from './types';
import axios from 'axios';

export const actions: ActionTree<RootState, RootState> = {
    loadSummaryData({ commit }): any {
        const summaryUrl = 'http://' + this.state.urlBase + '/api/portfolio/XXXXXXXXX/summary';
        axios.get(summaryUrl).then((resp) => {
            commit('loadSummaryData', resp.data);
        }).catch(error => {
            throw new Error(`API ${error}`);
        });
  },  
};
