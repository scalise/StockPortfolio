<template>
    <v-row>
        <v-col lg="12" md="12">
            <v-card>               
                <v-list>
                    <template v-for="(item, index) in items">

                        <v-list-item :key="item.title"
                                     @click="">

                            <v-list-item-content>
                                <v-list-item-title v-html="item.title"></v-list-item-title>
                            </v-list-item-content>

                            <v-list-item-action>
                                <v-list-item-title v-html="`<span>$</span>${item.amount}`"></v-list-item-title>
                            </v-list-item-action>

                        </v-list-item>
                    </template>
                </v-list>
            </v-card>
        </v-col>
</v-row>
</template>
<script>
    import axios from 'axios';

    export default {
        name: 'PortfolioSummary',
        mounted() {
            const summaryUrl = 'http://' + this.$store.state.urlBase + '/api/portfolio/XXXXXXXXX/summary';
            axios.get(summaryUrl).then((resp) => {
                this.items = [];

                const titleKey = 'title';
                const amountKey = 'amount'; 

                const obj1 = {};
                obj1[titleKey] = 'Total Cash'; 
                obj1[amountKey] = resp.data.totalCash;
                this.items.push(obj1);
                
                const obj2 = {};
                obj2[titleKey] = 'Total Positions';
                obj2[amountKey] = resp.data.positions;
                this.items.push(obj2);
            });
        },
        data() {
            return {
                items: []
            };
        }
    };
</script>