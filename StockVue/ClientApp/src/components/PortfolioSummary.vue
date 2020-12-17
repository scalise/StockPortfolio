<template>
    <v-row>
        <v-col lg="12" md="12">
            <v-card>
                <v-list>
                    <template v-for="(item, index) in summary">

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

    export default {
        name: 'PortfolioSummary',        
        async mounted() {
            this.$store.dispatch("loadSummaryData");
        },
        computed: {            
            summary() {
                let items = [];

                let data = this.$store.state.summary;
                if (data) {
                    const titleKey = 'title';
                    const amountKey = 'amount';

                    const obj1 = {};
                    obj1[titleKey] = 'Total Cash';
                    obj1[amountKey] = data.totalCash;
                    items.push(obj1);

                    const obj2 = {};
                    obj2[titleKey] = 'Total Positions';
                    obj2[amountKey] = data.totalPositions;
                    items.push(obj2);
                }
                return items;
            }
        },
    };
</script>